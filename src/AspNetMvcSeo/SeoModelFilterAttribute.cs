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

            base.OnResultExecuting(filterContext);

            this.PopulateSeoModelValues(filterContext);
        }

        internal void PopulateSeoModelValues(ControllerContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            var model = filterContext.Controller.ViewData.Model as ISeoModel;
            if (model == null)
            {
                return;
            }

            var seoHelper = new SeoHelper(filterContext.HttpContext);

            this.PopulateSeoModelValues(model, seoHelper);
        }

        internal void PopulateSeoModelValues(ISeoModel seoModel, SeoHelper seoHelper)
        {
            if (seoModel == null)
            {
                throw new ArgumentNullException(nameof(seoModel));
            }
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            seoModel.PopulateSeo(seoHelper);
        }
    }
}