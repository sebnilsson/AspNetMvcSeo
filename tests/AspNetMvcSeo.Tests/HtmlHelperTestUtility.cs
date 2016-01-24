using System.IO;
using System.Web.Mvc;
using System.Web.Routing;

using Moq;

namespace AspNetMvcSeo.Tests
{
    public static class HtmlHelperTestUtility
    {
        public static HtmlHelper Get(RequestContext requestContext = null)
        {
            requestContext = requestContext ?? RequestContextTestUtility.Get();

            var controller = new Mock<ControllerBase>();
            var textWriter = new Mock<TextWriter>();

            var routeData = new RouteData();
            var tempData = new TempDataDictionary();
            var controllerContext = new ControllerContext(requestContext.HttpContext, routeData, controller.Object);

            var viewData = new ViewDataDictionary();

            var view = new Mock<IView>();

            var viewContext = new Mock<ViewContext>(
                controllerContext,
                view.Object,
                viewData,
                tempData,
                textWriter.Object);
            viewContext.Setup(x => x.HttpContext).Returns(requestContext.HttpContext);

            var viewDataContainer = new Mock<IViewDataContainer>();
            viewDataContainer.Setup(x => x.ViewData).Returns(viewData);

            var htmlHelper = new HtmlHelper(viewContext.Object, viewDataContainer.Object);
            return htmlHelper;
        }
    }
}