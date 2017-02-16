using System;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    internal static class SeoHelperLinkCanonicalHelper
    {
        public static string GetLinkCanonical(
            HttpContextBase httpContext,
            string linkCanonical,
            string linkCanonicalBase)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (linkCanonical == null || Uri.IsWellFormedUriString(linkCanonical, UriKind.Absolute))
            {
                return linkCanonical;
            }

            var linkCanonicalAppAbsolute = UrlHelper.GenerateContentUrl(linkCanonical, httpContext);

            string baseCombinedLinkCanonical = GetBaseCombinedLinkCanonical(linkCanonicalAppAbsolute, linkCanonicalBase);
            if (baseCombinedLinkCanonical != null)
            {
                return baseCombinedLinkCanonical;
            }

            string requestCombinedLinkCanonical = GetRequestCombinedLinkCanonical(httpContext, linkCanonicalAppAbsolute);
            return requestCombinedLinkCanonical;
        }

        private static string GetBaseCombinedLinkCanonical(string linkCanonicalAppAbsolute, string linkCanonicalBase)
        {
            if (linkCanonicalBase == null)
            {
                return null;
            }

            string combinedLinkCanoncial = $"{linkCanonicalBase.TrimEnd('/')}/{linkCanonicalAppAbsolute.TrimStart('/')}";
            return combinedLinkCanoncial;
        }

        private static string GetRequestCombinedLinkCanonical(
            HttpContextBase httpContext,
            string linkCanonicalAppAbsolute)
        {
            var requestUri = GetRequestUri(httpContext);

            if (requestUri == null)
            {
                string message = $"{nameof(httpContext.Request.Url)} in {nameof(HttpContextBase)} cannot be null.";
                throw new ArgumentOutOfRangeException(nameof(httpContext), message);
            }

            int queryIndex = linkCanonicalAppAbsolute.IndexOf('?');

            string uriPath = (queryIndex >= 0)
                                 ? linkCanonicalAppAbsolute.Substring(0, queryIndex)
                                 : linkCanonicalAppAbsolute;
            string uriQuery = (queryIndex >= 0) ? linkCanonicalAppAbsolute.Substring(queryIndex + 1) : string.Empty;
            int uriPort = requestUri.Authority.Contains(":") ? requestUri.Port : -1;

            var uri = new UriBuilder(requestUri.AbsoluteUri) { Path = uriPath, Query = uriQuery, Port = uriPort };

            string absoluteLinkCanonicalUrl = uri.ToString();

            if (string.IsNullOrWhiteSpace(absoluteLinkCanonicalUrl)
                || !Uri.IsWellFormedUriString(absoluteLinkCanonicalUrl, UriKind.Absolute))
            {
                return null;
            }

            return absoluteLinkCanonicalUrl;
        }

        private static Uri GetRequestUri(HttpContextBase httpContext)
        {
            var request = httpContext.Request;
            if (request == null)
            {
                string message = $"{nameof(httpContext.Request)} in {nameof(HttpContextBase)} cannot be null.";
                throw new ArgumentOutOfRangeException(nameof(httpContext), message);
            }

            var requestUri = request.Url;
            return requestUri;
        }
    }
}