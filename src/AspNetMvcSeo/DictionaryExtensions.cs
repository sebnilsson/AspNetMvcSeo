using System;
using System.Collections;

namespace AspNetMvcSeo
{
    internal static class DictionaryExtensions
    {
        public static T TryGet<T>(this IDictionary dictionary, object key)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!dictionary.Contains(key))
            {
                return default(T);
            }

            var item = dictionary[key];
            return (item is T) ? (T)item : default(T);
        }
    }
}