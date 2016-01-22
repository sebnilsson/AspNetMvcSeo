using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaNoIndexAttribute : SeoAttributeBase
    {
        private readonly bool noIndex;

        public SeoMetaNoIndexAttribute(bool noIndex = true)
        {
            this.noIndex = noIndex;
        }

        public override void SetSeoValues(SeoHelper seoHelper)
        {
            seoHelper.MetaNoIndex = this.noIndex;
        }
    }
}