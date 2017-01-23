using System;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public static class HtmlHelperSeoExtensions
    {
        public static IHtmlString SeoLinkCanonical(this HtmlHelper htmlHelper, string linkCanonical = null)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            var seoHelper = GetSeoHelper(htmlHelper);

            linkCanonical = linkCanonical ?? seoHelper.LinkCanonical;
            if (linkCanonical == null)
            {
                return null;
            }

            var httpContext = htmlHelper.ViewContext.HttpContext;

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

        public static IHtmlString SeoMetaDescription(this HtmlHelper htmlHelper, string metaDescription = null)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            var seoHelper = GetSeoHelper(htmlHelper);

            metaDescription = metaDescription ?? seoHelper.MetaDescription;
            if (metaDescription == null)
            {
                return null;
            }

            return htmlHelper.GetMetaTag("description", metaDescription);
        }

        public static IHtmlString SeoMetaKeywords(this HtmlHelper htmlHelper, string metaKeywords = null)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            var seoHelper = GetSeoHelper(htmlHelper);

            metaKeywords = metaKeywords ?? seoHelper.MetaKeywords;
            if (metaKeywords == null)
            {
                return null;
            }

            return htmlHelper.GetMetaTag("keywords", metaKeywords);
        }

        public static IHtmlString SeoMetaRobotsIndex(this HtmlHelper htmlHelper, RobotsIndex? robotsIndex = null)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            var seoHelper = GetSeoHelper(htmlHelper);

            robotsIndex = robotsIndex ?? seoHelper.MetaRobotsIndex;
            if (robotsIndex == null)
            {
                return null;
            }

            string content = RobotsIndexManager.GetMetaContent(robotsIndex.Value);
            return htmlHelper.GetMetaTag("robots", content);
        }

        public static IHtmlString SeoTitle(this HtmlHelper htmlHelper, string title = null)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            var seoHelper = GetSeoHelper(htmlHelper);

            title = title ?? seoHelper.Title;
            if (title == null)
            {
                return null;
            }

            var tag = new TagBuilder("title") { InnerHtml = HttpUtility.HtmlEncode(title) };

            return new HtmlString(tag.ToString());
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

        private static SeoHelper GetSeoHelper(this HtmlHelper htmlHelper)
        {
            if (htmlHelper.ViewContext == null)
            {
                string message = $"{nameof(htmlHelper.ViewContext)} in {nameof(HtmlHelper)} cannot be null.";
                throw new ArgumentOutOfRangeException(nameof(htmlHelper), message);
            }

            var seoHelper = new SeoHelper(htmlHelper.ViewContext.HttpContext);
            return seoHelper;
        }

        private static IHtmlString GetMetaTag(this HtmlHelper htmlHelper, string name, string content)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
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