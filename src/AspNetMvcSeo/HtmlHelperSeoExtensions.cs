using System;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public static class HtmlHelperSeoExtensions
    {
        public const string GoogleBotMetaName = "GOOGLEBOT";

        public const string MetaIndexIndex = "INDEX";

        public const string MetaIndexNoIndex = "NOINDEX";

        public const string MetaIndexFollow = "FOLLOW";

        public const string MetaIndexNoFollow = "NOFOLLOW";

        public const string RobotsMetaName = "ROBOTS";

        public static IHtmlString LinkCanonical(this HtmlHelper helper, string linkCanonical = null)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var seo = new SeoHelper(helper.ViewContext);

            linkCanonical = linkCanonical ?? seo.LinkCanonical;
            if (linkCanonical == null)
            {
                return null;
            }

            var tag = new TagBuilder("link");
            tag.Attributes["rel"] = "canonical";
            tag.Attributes["href"] = HttpUtility.HtmlAttributeEncode(linkCanonical);

            return new HtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }

        public static IHtmlString MetaDescription(this HtmlHelper helper, string metaDescription = null)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var seoHelper = new SeoHelper(helper.ViewContext);

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

            var seoHelper = new SeoHelper(helper.ViewContext);

            metaKeywords = metaKeywords ?? seoHelper.MetaKeywords;
            if (metaKeywords == null)
            {
                return null;
            }

            return helper.Meta("keywords", metaKeywords);
        }

        public static IHtmlString MetaRobotsNoIndex(this HtmlHelper helper)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var robotsIndex = RobotsIndexManager.GetForNoIndex(noIndex: true);

            return helper.MetaRobotsIndex(robotsIndex);
        }

        public static IHtmlString MetaRobotsIndex(this HtmlHelper helper, RobotsIndex? robotsIndex = null)
        {
            if (helper == null)
            {
                throw new ArgumentNullException(nameof(helper));
            }

            var seo = new SeoHelper(helper.ViewContext);

            robotsIndex = robotsIndex ?? seo.MetaRobotsIndex;
            if (robotsIndex == null)
            {
                return null;
            }

            string content = RobotsIndexManager.GetMetaContent(robotsIndex.Value);

            var googleTag = Meta(helper, GoogleBotMetaName, content);
            var robotsTag = Meta(helper, RobotsMetaName, content);

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

            var seo = new SeoHelper(helper.ViewContext);

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