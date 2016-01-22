using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaRobotsIndexAttribute : SeoAttributeBase
    {
        private readonly RobotsIndex? robotsIndex;

        public SeoMetaRobotsIndexAttribute(RobotsIndex? robotsIndex = null)
        {
            this.robotsIndex = robotsIndex;
        }

        public override void SetSeoValues(SeoHelper seoHelper)
        {
            seoHelper.MetaRobotsIndex = this.robotsIndex;
        }
    }
}