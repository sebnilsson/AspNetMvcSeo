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

            var seoHelper = new SeoHelper(filterContext.RequestContext);

            this.SetSeoValues(seoHelper);
        }

        public abstract void SetSeoValues(SeoHelper seoHelper);
    }
}