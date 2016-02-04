using System;

namespace AspNetMvcSeo
{
    internal static class RobotsIndexManager
    {
        public const RobotsIndex DefaultRobotsNoIndex = RobotsIndex.NoIndexFollow;

        public const string IndexNoFollow = "INDEX, NOFOLLOW";

        public const string NoIndexFollow = "NOINDEX, FOLLOW";

        public const string NoIndexNoFollow = "NOINDEX, NOFOLLOW";

        public static string GetMetaContent(RobotsIndex robotsIndex)
        {
            switch (robotsIndex)
            {
                case RobotsIndex.IndexNoFollow:
                    return IndexNoFollow;
                case RobotsIndex.NoIndexFollow:
                    return NoIndexFollow;
                case RobotsIndex.NoIndexNoFollow:
                    return NoIndexNoFollow;
                default:
                    string message = $"No mapping found for {nameof(RobotsIndex)} value '{robotsIndex}'.";
                    throw new ArgumentOutOfRangeException(nameof(robotsIndex), message);
            }
        }

        public static RobotsIndex? GetForNoIndex(bool noIndex)
        {
            var robotsIndex = noIndex ? DefaultRobotsNoIndex : (RobotsIndex?)null;
            return robotsIndex;
        }
    }
}