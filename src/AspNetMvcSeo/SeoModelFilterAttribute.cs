using System;
using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public class SeoModelFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            this.HandleSeoValues(filterContext);
        }

        internal void HandleSeoValues(ControllerContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            var seoModel = filterContext.Controller.ViewData.Model as ISeoModel;
            if (seoModel == null)
            {
                return;
            }

            var seoHelper = new SeoHelper(filterContext.RequestContext);

            this.HandleSeoValues(seoModel, seoHelper);
        }

        internal void HandleSeoValues(ISeoModel seoModel, SeoHelper seoHelper)
        {
            if (seoModel == null)
            {
                throw new ArgumentNullException(nameof(seoModel));
            }
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            seoModel.OnHandleSeoValues(seoHelper);
        }
    }
}