using System;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public abstract class SeoAttributeBase : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            var seoHelper = new SeoHelper(filterContext.HttpContext);

            this.SetSeoValues(seoHelper);
        }

        public abstract void SetSeoValues(SeoHelper seoHelper);
    }
}