using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcSeo
{
    public static class UriUtility
    {
        internal const string AppRelativeUrlCharacter = "~";

        private const int UriNoPort = -1;

        public static string GetAbsoluteUrl(string virtualRelativePath, RequestContext requestContext)
        {
            if (virtualRelativePath == null)
            {
                throw new ArgumentNullException(nameof(virtualRelativePath));
            }
            if (requestContext == null)
            {
                throw new ArgumentNullException(nameof(requestContext));
            }

            var urlHelper = new UrlHelper(requestContext);

            var absolutePath = urlHelper.Content(virtualRelativePath);

            var requestUrl = requestContext.HttpContext?.Request?.Url;

            string absoluteUrl = GetAbsoluteUrlInternal(absolutePath, requestUrl);
            return absoluteUrl;
        }

        internal static string GetAbsoluteUrlInternal(string absolutePath, Uri requestUrl)
        {
            if (absolutePath == null)
            {
                throw new ArgumentNullException(nameof(absolutePath));
            }
            if (absolutePath.StartsWith(AppRelativeUrlCharacter))
            {
                string message =
                    $"Value for '{nameof(absolutePath)}' starts with app-relative URL-character '{AppRelativeUrlCharacter}'.";
                throw new ArgumentOutOfRangeException(nameof(absolutePath), message);
            }
            if (requestUrl == null)
            {
                throw new ArgumentNullException(nameof(requestUrl));
            }

            var fragmentSplit = absolutePath.Split('#').ToList();
            string fragment = (fragmentSplit.Count > 1) ? fragmentSplit.LastOrDefault() : null;

            string fragmentRest = fragmentSplit.FirstOrDefault() ?? absolutePath;

            var queryStringSplit = fragmentRest.Split('?').ToList();
            string queryString = (queryStringSplit.Count > 1) ? queryStringSplit.LastOrDefault() : null;

            string path = queryStringSplit.FirstOrDefault() ?? absolutePath;

            string extraValue = (!string.IsNullOrWhiteSpace(queryString) ? $"?{queryString}" : null)
                                + (!string.IsNullOrWhiteSpace(fragment) ? $"#{fragment}" : null);

            var uriBuilder = new UriBuilder(requestUrl.Scheme, requestUrl.Host, UriNoPort, path, extraValue);

            string absoluteUrl = uriBuilder.ToString();
            return absoluteUrl;
        }
    }
}