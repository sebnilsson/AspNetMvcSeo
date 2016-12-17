using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoLinkCanonicalAttribute : SeoAttributeBase
    {
        private readonly string linkCanonical;

        public SeoLinkCanonicalAttribute(string linkCanonical)
        {
            this.linkCanonical = linkCanonical;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            seoHelper.LinkCanonical = this.linkCanonical;
        }
    }
}