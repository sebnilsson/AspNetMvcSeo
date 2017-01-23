using System;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public static class ControllerBaseExtensions
    {
        public static SeoHelper GetSeoHelper(this ControllerBase controller)
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            var seoHelper = new SeoHelper(controller.ControllerContext.HttpContext);
            return seoHelper;
        }
    }
}