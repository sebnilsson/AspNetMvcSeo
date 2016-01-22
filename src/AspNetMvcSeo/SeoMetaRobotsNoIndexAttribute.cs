using System;

namespace AspNetMvcSeo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class SeoMetaRobotsNoIndexAttribute : SeoMetaRobotsIndexAttribute
    {
        public SeoMetaRobotsNoIndexAttribute()
            : base(RobotsIndexManager.DefaultRobotsNoIndex)
        {
        }
    }
}