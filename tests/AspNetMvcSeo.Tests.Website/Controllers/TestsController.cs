using System;
using System.Web.Mvc;

using AspNetMvcSeo.Tests.Website.Models;

namespace AspNetMvcSeo.Tests.Website.Controllers
{
    [SeoPageTitle("Controller-title")]
    public class TestsController : SeoController
    {
        public ActionResult Index()
        {
            var model = TestActionsViewModel.Default;

            return this.View("~/Views/Home/Index.cshtml", model);
        }

        [SeoPageTitle("LinkCanonical")]
        public ActionResult LinkCanonical()
        {
            this.Seo.LinkCanonical = "~/Tests/LinkCanonicalAttribute_FromHelperProperty/?abc=123&param=param";

            return this.View();
        }

        [SeoLinkCanonical("https://testwebsite.com/Tests/LinkCanonicalAttribute_FromAttribute/?abc=123&param=param")]
        [SeoPageTitle("LinkCanonicalAttribute")]
        public ActionResult LinkCanonicalAttribute()
        {
            return this.View("LinkCanonical");
        }

        [SeoPageTitle("MetaDescription")]
        public ActionResult MetaDescription()
        {
            this.Seo.MetaDescription = $"Test meta-description{Environment.NewLine}Newline-content";

            return this.View();
        }

        [SeoMetaDescription("Test meta-description\r\nNewline-content")]
        [SeoPageTitle("MetaDescriptionAttribute")]
        public ActionResult MetaDescriptionAttribute()
        {
            return this.View("MetaDescription");
        }

        [SeoPageTitle("MetaKeywords")]
        public ActionResult MetaKeywords()
        {
            this.Seo.MetaKeywords = $"Test meta-keywords{Environment.NewLine}Newline-content";

            return this.View();
        }

        [SeoMetaKeywords("Test meta-keywords\r\nNewline-content")]
        [SeoPageTitle("MetaKeywordsAttribute")]
        public ActionResult MetaKeywordsAttribute()
        {
            return this.View("MetaKeywords");
        }

        [SeoPageTitle("MetaRobotsIndexAttribute")]
        [SeoMetaRobotsIndex]
        public ActionResult MetaRobotsIndexAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoPageTitle("MetaRobotsIndexIndexNoFollow")]
        public ActionResult MetaRobotsIndexIndexNoFollow()
        {
            this.Seo.MetaRobotsIndex = RobotsIndex.IndexNoFollow;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.IndexNoFollow)]
        [SeoPageTitle("MetaRobotsIndexIndexNoFollowAttribute")]
        public ActionResult MetaRobotsIndexIndexNoFollowAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoPageTitle("MetaRobotsIndexNoIndexFollow")]
        public ActionResult MetaRobotsIndexNoIndexFollow()
        {
            this.Seo.MetaRobotsIndex = RobotsIndex.NoIndexFollow;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.NoIndexFollow)]
        [SeoPageTitle("MetaRobotsIndexNoIndexFollowAttribute")]
        public ActionResult MetaRobotsIndexNoIndexFollowAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoPageTitle("MetaRobotsIndexNoIndexNoFollow")]
        public ActionResult MetaRobotsIndexNoIndexNoFollow()
        {
            this.Seo.MetaRobotsIndex = RobotsIndex.NoIndexNoFollow;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsIndex(RobotsIndex.NoIndexNoFollow)]
        [SeoPageTitle("MetaRobotsIndexNoIndexNoFollowAttribute")]
        public ActionResult MetaRobotsIndexNoIndexNoFollowAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoPageTitle("MetaRobotsNoIndex")]
        public ActionResult MetaRobotsNoIndex()
        {
            this.Seo.MetaRobotsNoIndex = true;

            return this.View("MetaRobotsIndex");
        }

        [SeoMetaRobotsNoIndex]
        [SeoPageTitle("MetaRobotsNoIndexAttribute")]
        public ActionResult MetaRobotsNoIndexAttribute()
        {
            return this.View("MetaRobotsIndex");
        }

        [SeoPageTitle("Overridden action-title", OverrideSectionTitle = true)]
        public ActionResult Title()
        {
            this.Seo.PageTitle = "Action-method-title";

            return this.View();
        }

        [SeoPageTitle("Action-title")]
        public ActionResult TitleAttribute()
        {
            return this.View("Title");
        }
    }
}