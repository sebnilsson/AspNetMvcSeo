using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaDescriptionAttribute : SeoAttributeBase
    {
        private readonly string metaDescription;

        public SeoMetaDescriptionAttribute(string metaDescription)
        {
            this.metaDescription = metaDescription;
        }

        public override void SetSeoValues(SeoHelper seoHelper)
        {
            seoHelper.MetaDescription = this.metaDescription;
        }
    }
}