using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class SeoPageTitleAttribute : SeoTitleAttributeBase
    {
        public SeoPageTitleAttribute(string title)
        {
            this.Title = title;
        }

        public SeoPageTitleAttribute()
        {
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            base.OnHandleSeoValues(seoHelper);

            seoHelper.PageTitle = this.Title;

            if (this.OverrideSectionTitle)
            {
                seoHelper.SectionTitle = null;
            }
        }

        public bool OverrideSectionTitle { get; set; }
    }
}