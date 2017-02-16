using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class SeoBaseTitleAttribute : SeoTitleAttributeBase
    {
        private readonly string title;

        public SeoBaseTitleAttribute(string title)
        {
            this.title = title;
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            base.OnHandleSeoValues(seoHelper);

            seoHelper.BaseTitle = this.title;
        }
    }
}