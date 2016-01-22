using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoPageTitleAttribute : SeoAttributeBase
    {
        private readonly string pageTitle;

        public SeoPageTitleAttribute(string pageTitle)
        {
            this.pageTitle = pageTitle;
        }

        public override void SetSeoValues(SeoHelper seoHelper)
        {
            seoHelper.PageTitle = this.pageTitle;
        }
    }
}