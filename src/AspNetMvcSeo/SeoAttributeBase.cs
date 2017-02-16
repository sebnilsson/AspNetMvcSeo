using System;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public abstract class SeoAttributeBase : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            var seoHelper = filterContext.Controller?.ViewData?.GetSeoHelper();
            
            this.OnHandleSeoValues(seoHelper);
        }

        public abstract void OnHandleSeoValues(SeoHelper seoHelper);
    }
}