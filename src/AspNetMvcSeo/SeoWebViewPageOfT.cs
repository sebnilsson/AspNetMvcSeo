﻿using System.Web.Mvc;

namespace AspNetMvcSeo
{
    public class SeoWebViewPage<TModel> : WebViewPage<TModel>
    {
        public SeoHelper Seo { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();

            this.Seo = this.GetSeoHelper();
        }

        public override void Execute()
        {
        }
    }
}