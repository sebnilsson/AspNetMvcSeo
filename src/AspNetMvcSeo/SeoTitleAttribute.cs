using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class SeoTitleAttribute : SeoAttributeBase
    {
        public SeoTitleAttribute(string title)
        {
            this.Title = title;
        }

        public SeoTitleAttribute()
        {
        }

        public override void OnHandleSeoValues(SeoHelper seoHelper)
        {
            if (seoHelper == null)
            {
                throw new ArgumentNullException(nameof(seoHelper));
            }

            seoHelper.SetTitle(this.Title, this.Override, this.Separator);
        }

        public bool Override { get; set; }

        public string Separator { get; set; }

        public string Title { get; set; }
    }
}