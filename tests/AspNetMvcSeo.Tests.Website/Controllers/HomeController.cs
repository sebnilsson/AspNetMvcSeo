using System.Web.Mvc;

using AspNetMvcSeo.Tests.Website.Models;

namespace AspNetMvcSeo.Tests.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = TestActionsViewModel.Default;

            return this.View(model);
        }
    }
}