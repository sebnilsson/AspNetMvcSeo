using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Moq;

namespace AspNetMvcSeo.Tests
{
    public static class HtmlHelperTestUtility
    {
        public static HtmlHelper Get(IDictionary seoData = null)
        {
            seoData = seoData ?? new Dictionary<object, object>();

            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(x => x.Items).Returns(seoData);

            var controller = new Mock<ControllerBase>();
            var textWriter = new Mock<TextWriter>();

            var routeData = new RouteData();
            var tempData = new TempDataDictionary();
            var controllerContext = new ControllerContext(httpContext.Object, routeData, controller.Object);

            var viewData = new ViewDataDictionary();

            var view = new Mock<IView>();

            var viewContext = new Mock<ViewContext>(
                controllerContext,
                view.Object,
                viewData,
                tempData,
                textWriter.Object);
            viewContext.Setup(x => x.HttpContext).Returns(httpContext.Object);

            var viewDataContainer = new Mock<IViewDataContainer>();
            viewDataContainer.Setup(x => x.ViewData).Returns(viewData);

            var htmlHelper = new HtmlHelper(viewContext.Object, viewDataContainer.Object);
            return htmlHelper;
        }
    }
}