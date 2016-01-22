using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoCanonicalLinkAttribute : SeoAttributeBase
    {
        private readonly string canonicalLink;

        public SeoCanonicalLinkAttribute(string canonicalLink)
        {
            this.canonicalLink = canonicalLink;
        }

        public override void SetSeoValues(SeoHelper seoHelper)
        {
            seoHelper.CanonicalLink = this.canonicalLink;
        }
    }
}