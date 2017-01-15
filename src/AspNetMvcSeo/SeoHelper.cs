using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcSeo
{
    public class SeoHelper
    {
        private const string DefaultTitleFormat = "{0} - {1}";

        private static readonly string LinkCanonicalKey = GetDataKey(nameof(LinkCanonical));

        private static readonly string MetaDescriptionKey = GetDataKey(nameof(MetaDescription));

        private static readonly string MetaKeywordsKey = GetDataKey(nameof(MetaKeywords));

        private static readonly string MetaRobotsIndexKey = GetDataKey(nameof(MetaRobotsIndex));

        private static readonly string PageTitleKey = GetDataKey(nameof(PageTitle));

        private static readonly string SectionTitleKey = GetDataKey(nameof(SectionTitle));

        private static readonly string TitleFormatKey = GetDataKey(nameof(TitleFormat));

        private readonly IDictionary seoData;

        public SeoHelper(RequestContext requestContext)
            : this(GetHttpContextItems(requestContext))
        {
        }

        internal SeoHelper(ViewContext viewContext)
            : this(GetRequestContext(viewContext))
        {
        }

        internal SeoHelper(IDictionary seoData)
        {
            if (seoData == null)
            {
                throw new ArgumentNullException(nameof(seoData));
            }

            this.seoData = seoData;
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
                return (this.MetaRobotsIndex == RobotsIndexManager.DefaultRobotsNoIndex);
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

        public string SectionTitle
        {
            get
            {
                return this.seoData.TryGet<string>(SectionTitleKey);
            }
            set
            {
                this.seoData[SectionTitleKey] = value;
            }
        }

        public string Title
        {
            get
            {
                bool isSectionTitleSet = !string.IsNullOrWhiteSpace(this.SectionTitle);
                bool isPageTitleSet = !string.IsNullOrWhiteSpace(this.PageTitle);

                if (isSectionTitleSet && isPageTitleSet)
                {
                    string title = string.Format(this.TitleFormat, this.PageTitle, this.SectionTitle);
                    return title;
                }

                if (!isSectionTitleSet)
                {
                    return !string.IsNullOrWhiteSpace(this.PageTitle) ? this.PageTitle : null;
                }

                return !string.IsNullOrWhiteSpace(this.SectionTitle) ? this.SectionTitle : null;
            }
        }

        public string TitleFormat
        {
            get
            {
                string format = this.seoData.TryGet<string>(TitleFormatKey);

                return !string.IsNullOrWhiteSpace(format) ? format : DefaultTitleFormat;
            }
            set
            {
                this.seoData[TitleFormatKey] = value;
            }
        }

        public string AddMetaKeyword(string addedKeyword)
        {
            if (addedKeyword == null)
            {
                throw new ArgumentNullException(nameof(addedKeyword));
            }

            string combinedMetaKeywords = CombineTexts(" ", this.MetaKeywords, addedKeyword);

            this.MetaKeywords = combinedMetaKeywords;

            return combinedMetaKeywords;
        }

        private static string CombineTexts(string separator, params string[] values)
        {
            var cleanedValues =
                (values?.Select(x => x?.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)) ?? Enumerable.Empty<string>())
                    .ToList();

            if (!cleanedValues.Any())
            {
                return null;
            }

            string combined = string.Join(separator, cleanedValues).Trim();
            return combined;
        }

        private static string GetDataKey(string name)
        {
            string key = $"{nameof(AspNetMvcSeo)}.{nameof(SeoHelper)}.{name}";
            return key;
        }

        private static IDictionary GetHttpContextItems(RequestContext requestContext)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException(nameof(requestContext));
            }
            if (requestContext.HttpContext == null)
            {
                string message = $"{nameof(requestContext.HttpContext)} in {nameof(RequestContext)} cannot be null.";
                throw new ArgumentOutOfRangeException(nameof(requestContext), message);
            }
            if (requestContext.HttpContext.Items == null)
            {
                string message =
                    $"{nameof(requestContext.HttpContext.Items)} in {nameof(requestContext.HttpContext)} cannot be null.";
                throw new ArgumentOutOfRangeException(nameof(requestContext), message);
            }

            return requestContext.HttpContext.Items;
        }

        private static RequestContext GetRequestContext(ViewContext viewContext)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }
            if (viewContext.RequestContext == null)
            {
                string message = $"{nameof(viewContext.RequestContext)} in {nameof(ViewContext)} cannot be null.";
                throw new ArgumentOutOfRangeException(nameof(viewContext), message);
            }

            return viewContext.RequestContext;
        }
    }
}