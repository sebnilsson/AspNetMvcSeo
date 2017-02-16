using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcSeo
{
    public abstract class SeoController : Controller
    {
        public SeoHelper Seo { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException(nameof(requestContext));
            }

            base.Initialize(requestContext);

            this.Seo = this.GetSeoHelper();
        }
    }
}