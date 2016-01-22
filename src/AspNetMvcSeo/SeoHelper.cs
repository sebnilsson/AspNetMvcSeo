using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public class SeoHelper
    {
        private static readonly string CanonicalLinkKey = GetKey(nameof(CanonicalLink));

        private static readonly Regex DoubleWhitespaceRegex = new Regex(@"\s{2,}");

        private static readonly string MetaDescriptionKey = GetKey(nameof(MetaDescription));

        private static readonly string MetaKeywordsKey = GetKey(nameof(MetaKeywords));

        private static readonly string MetaRobotsIndexKey = GetKey(nameof(MetaRobotsIndex));

        private static readonly string PageTitleKey = GetKey(nameof(PageTitle));

        private static readonly string SiteTitleKey = GetKey(nameof(SiteTitle));

        private readonly IDictionary seoData;

        internal static readonly object DefaultSiteTitleLock = new object();

        private static string defaultSiteTitle;

        public SeoHelper(HttpContextBase httpContext, string siteTitle = null)
            : this(GetSeoData(httpContext), siteTitle)
        {
        }

        public SeoHelper(IDictionary seoData, string siteTitle = null)
        {
            if (seoData == null)
            {
                throw new ArgumentNullException(nameof(seoData));
            }

            this.seoData = seoData;

            if (siteTitle != null)
            {
                this.SiteTitle = siteTitle;
            }
        }

        internal SeoHelper(HtmlHelper htmlHelper)
            : this(GetHttpContext(htmlHelper))
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

        public string CanonicalLink
        {
            get
            {
                return this.seoData.TryGet<string>(CanonicalLinkKey);
            }
            set
            {
                this.seoData[CanonicalLinkKey] = value;
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

        private static HttpContextBase GetHttpContext(HtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }
            if (htmlHelper.ViewContext == null)
            {
                string message = $"Provided {nameof(HtmlHelper)} has null value for '{nameof(HtmlHelper.ViewContext)}'.";
                throw new ArgumentOutOfRangeException(nameof(htmlHelper), message);
            }

            return htmlHelper.ViewContext.HttpContext;
        }

        private static string GetKey(string name)
        {
            string key = $"{nameof(AspNetMvcSeo)}.{nameof(SeoHelper)}.{name}";
            return key;
        }

        private static IDictionary GetSeoData(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            if (httpContext.Items == null)
            {
                string message = $"Provided {nameof(HttpContextBase)}.{nameof(HttpContextBase.Items)} cannot be null.";
                throw new ArgumentOutOfRangeException(nameof(httpContext), message);
            }

            return httpContext.Items;
        }
    }
}