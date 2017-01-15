using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class SeoSectionTitleAttribute : SeoTitleAttributeBase
    {
        public SeoSectionTitleAttribute(string title)
        {
            this.Title = title;
        }

        public SeoSectionTitleAttribute()
        {
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            base.OnHandleSeoValues(seoHelper);

            seoHelper.SectionTitle = this.Title;
        }
    }
}