using System;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public static class HtmlHelperSeoExtensions
    {
        public static IHtmlString SeoLinkCanonical(this HtmlHelper helper, string linkCanonical = null)
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

            var httpContext = helper.ViewContext.HttpContext;

            var requestUri = httpContext.Request.Url;
            if (requestUri == null)
            {
                return null;
            }

            string linkCanonicalHref = GetAbsoluteLinkCanonical(requestUri, linkCanonical, httpContext);

            if (string.IsNullOrWhiteSpace(linkCanonicalHref)
                || !Uri.IsWellFormedUriString(linkCanonicalHref, UriKind.Absolute))
            {
                return null;
            }

            var tag = new TagBuilder("link");
            tag.Attributes["rel"] = "canonical";
            tag.Attributes["href"] = linkCanonicalHref;

            return new HtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }

        private static string GetAbsoluteLinkCanonical(
            Uri requestUri,
            string linkCanonical,
            HttpContextBase httpContext)
        {
            if (Uri.IsWellFormedUriString(linkCanonical, UriKind.Absolute))
            {
                return linkCanonical;
            }

            var appAbsolutePath = UrlHelper.GenerateContentUrl(linkCanonical, httpContext);

            int queryIndex = appAbsolutePath.IndexOf('?');

            string uriPath = (queryIndex >= 0) ? appAbsolutePath.Substring(0, queryIndex) : appAbsolutePath;
            string uriQuery = (queryIndex >= 0) ? appAbsolutePath.Substring(queryIndex + 1) : string.Empty;
            int uriPort = requestUri.Authority.Contains(":") ? requestUri.Port : -1;

            var uri = new UriBuilder(requestUri.AbsoluteUri) { Path = uriPath, Query = uriQuery, Port = uriPort };

            string absoluteLinkCanonicalUrl = uri.ToString();
            return absoluteLinkCanonicalUrl;
        }

        public static IHtmlString SeoMetaDescription(this HtmlHelper helper, string metaDescription = null)
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

        public static IHtmlString SeoMetaKeywords(this HtmlHelper helper, string metaKeywords = null)
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

        public static IHtmlString SeoMetaRobotsIndex(this HtmlHelper helper, RobotsIndex? robotsIndex = null)
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
            return helper.Meta("robots", content);
        }

        public static IHtmlString SeoTitle(this HtmlHelper helper, string title = null)
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

        private static IHtmlString Meta(this HtmlHelper helper, string name, string content)
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
    }
}