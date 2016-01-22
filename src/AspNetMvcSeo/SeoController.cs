using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvcSeo
{
    public class SeoController : Controller
    {
        public SeoHelper Seo { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            this.Seo = new SeoHelper(this.HttpContext);
        }
    }
}