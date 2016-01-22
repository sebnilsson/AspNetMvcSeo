using System;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public static class HtmlHelperSeoExtensions
    {
        public const string GoogleBotMetaName = "GOOGLEBOT";

        public const string RobotsMetaName = "ROBOTS";

        public static IHtmlString CanonicalLink(this HtmlHelper helper, string canonicalLink = null)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var seo = new SeoHelper(helper);

            canonicalLink = canonicalLink ?? seo.CanonicalLink;
            if (canonicalLink == null)
            {
                return null;
            }

            var tag = new TagBuilder("link");
            tag.Attributes["rel"] = "canonical";
            tag.Attributes["href"] = HttpUtility.HtmlAttributeEncode(canonicalLink);

            return new HtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }

        public static IHtmlString MetaDescription(this HtmlHelper helper, string metaDescription = null)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var seoHelper = new SeoHelper(helper);

            metaDescription = metaDescription ?? seoHelper.MetaDescription;
            if (metaDescription == null)
            {
                return null;
            }

            return helper.Meta("description", metaDescription);
        }

        public static IHtmlString MetaKeywords(this HtmlHelper helper, string metaKeywords = null)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var seoHelper = new SeoHelper(helper);

            metaKeywords = metaKeywords ?? seoHelper.MetaKeywords;
            if (metaKeywords == null)
            {
                return null;
            }

            return helper.Meta("keywords", metaKeywords);
        }

        public static IHtmlString MetaNoIndex(this HtmlHelper helper, bool? noIndex = null)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var seo = new SeoHelper(helper);

            noIndex = noIndex ?? seo.MetaNoIndex;
            if (noIndex == null)
            {
                return null;
            }

            string metaTagAttr = noIndex.Value ? "NOINDEX,FOLLOW" : "INDEX,FOLLOW";

            var googleTag = Meta(helper, GoogleBotMetaName, metaTagAttr);
            var robotsTag = Meta(helper, RobotsMetaName, metaTagAttr);

            var combinedTags = $"{googleTag}{Environment.NewLine}{robotsTag}";

            return new HtmlString(combinedTags);
        }

        public static IHtmlString Meta(this HtmlHelper helper, string name, string content)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (content == null)
            {
                return null;
            }

            var tag = new TagBuilder("meta");
            tag.Attributes["name"] = name;
            tag.Attributes["content"] = content;

            return new HtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }

        public static IHtmlString Title(this HtmlHelper helper, string title = null)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var seo = new SeoHelper(helper);

            title = title ?? seo.Title;
            if (title == null)
            {
                return null;
            }

            var tag = new TagBuilder("title") { InnerHtml = HttpUtility.HtmlEncode(title) };

            return new HtmlString(tag.ToString());
        }
    }
}