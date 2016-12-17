using System;
using System.Collections;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcSeo
{
    using System.Linq;

    public class SeoHelper
    {
        private const string DefaultTitleSeparator = " - ";

        private static readonly string LinkCanonicalKey = GetDataKey(nameof(LinkCanonical));

        private static readonly string MetaDescriptionKey = GetDataKey(nameof(MetaDescription));

        private static readonly string MetaKeywordsKey = GetDataKey(nameof(MetaKeywords));

        private static readonly string MetaRobotsIndexKey = GetDataKey(nameof(MetaRobotsIndex));

        private static readonly string TitleKey = GetDataKey(nameof(Title));

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
                return this.MetaRobotsIndex.HasValue;
            }
            set
            {
                var metaRobotsIndex = value ? RobotsIndexManager.DefaultRobotsNoIndex : (RobotsIndex?)null;

                this.MetaRobotsIndex = metaRobotsIndex;
            }
        }

        public string Title
        {
            get
            {
                return this.seoData.TryGet<string>(TitleKey);
            }
            set
            {
                this.SetTitle(value);
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

        public void SetTitle(string value, bool overrideTitle = false, string separator = null)
        {
            separator = separator ?? DefaultTitleSeparator;

            if (overrideTitle)
            {
                this.seoData[TitleKey] = value;
            }
            else
            {
                string existingTitle = this.seoData.TryGet<string>(TitleKey);

                string combinedTitle = CombineTexts(separator, value, existingTitle);

                this.seoData[TitleKey] = combinedTitle;
            }
        }

        private static string CombineTexts(string separator, params string[] values)
        {
            var cleanedValues = values?.Select(x => x?.Trim()).Where(x => !string.IsNullOrWhiteSpace(x))
                                ?? Enumerable.Empty<string>();

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