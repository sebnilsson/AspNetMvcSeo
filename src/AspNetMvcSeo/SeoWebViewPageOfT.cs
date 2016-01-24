using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public class SeoWebViewPage<TModel> : WebViewPage<TModel>
    {
        public SeoHelper Seo { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();

            this.Seo = new SeoHelper(this.ViewContext);
        }

        public override void Execute()
        {
        }
    }
}