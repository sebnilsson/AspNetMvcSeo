using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcSeo
{
    public class SeoHelper
    {
        private static readonly string LinkCanonicalKey = GetKey(nameof(LinkCanonical));

        private static readonly Regex DoubleWhitespaceRegex = new Regex(@"\s{2,}");

        private static readonly string MetaDescriptionKey = GetKey(nameof(MetaDescription));

        private static readonly string MetaKeywordsKey = GetKey(nameof(MetaKeywords));

        private static readonly string MetaRobotsIndexKey = GetKey(nameof(MetaRobotsIndex));

        private static readonly string PageTitleKey = GetKey(nameof(PageTitle));

        private static readonly string SiteTitleKey = GetKey(nameof(SiteTitle));

        private readonly IDictionary seoData;

        internal static readonly object DefaultSiteTitleLock = new object();

        private static string defaultSiteTitle;

        public SeoHelper(RequestContext requestContext, string siteTitle = null)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException(nameof(requestContext));
            }

            this.seoData = GetSeoData(requestContext);

            this.RequestContext = requestContext;

            if (siteTitle != null)
            {
                this.SiteTitle = siteTitle;
            }
        }

        internal SeoHelper(ViewContext viewContext, string siteTitle = null)
            : this(GetRequestContext(viewContext), siteTitle)
        {
        }

        public static string DefaultSiteTitle
        {
            get
            {
                lock (DefaultSiteTitleLock)
                {
                    return defaultSiteTitle;
                }
            }
            set
            {
                lock (DefaultSiteTitleLock)
                {
                    defaultSiteTitle = value;
                }
            }
        }

        public string LinkCanonical
        {
            get
            {
                return this.seoData.TryGet<string>(LinkCanonicalKey);
            }
            set
            {
                this.seoData[LinkCanonicalKey] = value;
            }
        }

        public string MetaDescription
        {
            get
            {
                return this.seoData.TryGet<string>(MetaDescriptionKey);
            }
            set
            {
                this.seoData[MetaDescriptionKey] = value;
            }
        }

        public string MetaKeywords
        {
            get
            {
                return this.seoData.TryGet<string>(MetaKeywordsKey);
            }
            set
            {
                this.seoData[MetaKeywordsKey] = value;
            }
        }

        public RobotsIndex? MetaRobotsIndex
        {
            get
            {
                return this.seoData.TryGet<RobotsIndex?>(MetaRobotsIndexKey);
            }
            set
            {
                this.seoData[MetaRobotsIndexKey] = value;
            }
        }

        public bool MetaRobotsNoIndex
        {
            get
            {
                return this.MetaRobotsIndex.HasValue;
            }
            set
            {
                var metaRobotsIndex = value ? RobotsIndexManager.DefaultRobotsNoIndex : (RobotsIndex?)null;

                this.MetaRobotsIndex = metaRobotsIndex;
            }
        }

        public string PageTitle
        {
            get
            {
                return this.seoData.TryGet<string>(PageTitleKey);
            }
            set
            {
                this.seoData[PageTitleKey] = value;
            }
        }

        public RequestContext RequestContext { get; }

        public string SiteTitle
        {
            get
            {
                string siteTitle = this.seoData.TryGet<string>(SiteTitleKey);

                return !string.IsNullOrWhiteSpace(siteTitle) ? siteTitle : DefaultSiteTitle;
            }
            set
            {
                this.seoData[SiteTitleKey] = value;
            }
        }

        public string Title
        {
            get
            {
                bool hasTitle = !string.IsNullOrWhiteSpace(this.PageTitle);
                bool hasBaseTitle = !string.IsNullOrWhiteSpace(this.SiteTitle);

                if (hasTitle && hasBaseTitle)
                {
                    return $"{this.PageTitle.Trim()} - {this.SiteTitle.Trim()}";
                }

                if (hasTitle)
                {
                    return this.PageTitle;
                }

                return this.SiteTitle;
            }
        }

        public string AddMetaKeyword(string addedKeyword)
        {
            if (addedKeyword == null)
            {
                throw new ArgumentNullException(nameof(addedKeyword));
            }

            string combinedMetaKeywords = CombineTexts(this.MetaKeywords, addedKeyword);

            this.MetaKeywords = combinedMetaKeywords;

            return combinedMetaKeywords;
        }

        private static string CombineTexts(string text1, string text2)
        {
            string combined = $"{text1} {text2}";

            combined = DoubleWhitespaceRegex.Replace(combined, " ");

            combined = combined.Trim();
            return combined;
        }

        private static string GetKey(string name)
        {
            string key = $"{nameof(AspNetMvcSeo)}.{nameof(SeoHelper)}.{name}";
            return key;
        }

        private static RequestContext GetRequestContext(ViewContext viewContext)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }

            return viewContext.RequestContext;
        }

        private static IDictionary GetSeoData(RequestContext requestContext)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException(nameof(requestContext));
            }
            if (requestContext.HttpContext == null)
            {
                throw new ArgumentOutOfRangeException(nameof(requestContext));
            }
            if (requestContext.HttpContext.Items == null)
            {
                throw new ArgumentOutOfRangeException(nameof(requestContext));
            }

            return requestContext.HttpContext.Items;
        }
    }
}