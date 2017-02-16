using System;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    internal static class ViewDataDictionaryExtensions
    {
        internal static readonly string ViewDataKey = typeof(SeoHelper).FullName;

        public static SeoHelper GetSeoHelper(this ViewDataDictionary viewData)
        {
            if (viewData == null)
            {
                throw new ArgumentNullException(nameof(viewData));
            }

            var seoHelperData = viewData[ViewDataKey] as SeoHelper;

            if (seoHelperData == null)
            {
                lock (viewData)
                {
                    seoHelperData = viewData[ViewDataKey] as SeoHelper;

                    if (seoHelperData == null)
                    {
                        seoHelperData = new SeoHelper();

                        viewData[ViewDataKey] = seoHelperData;
                    }
                }
            }

            return seoHelperData;
        }
    }
}