using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaRobotsIndexAttribute : SeoAttributeBase
    {
        private readonly RobotsIndex? robotsIndex;

        public SeoMetaRobotsIndexAttribute(RobotsIndex robotsIndex)
        {
            this.robotsIndex = robotsIndex;
        }

        public SeoMetaRobotsIndexAttribute()
        {
            this.robotsIndex = null;
        }

        public override void SetSeoValues(SeoHelper seoHelper)
        {
            seoHelper.MetaRobotsIndex = this.robotsIndex;
        }
    }
}