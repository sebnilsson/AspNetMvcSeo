using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoTitleAttribute : SeoAttributeBase
    {
        private readonly string pageTitle;

        public SeoTitleAttribute(string pageTitle)
        {
            this.pageTitle = pageTitle;
        }

        public override void SetSeoValues(SeoHelper seoHelper)
        {
            seoHelper.PageTitle = this.pageTitle;
        }
    }
}