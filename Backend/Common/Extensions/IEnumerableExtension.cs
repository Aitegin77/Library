using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class IEnumerableExtension
    {
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> lst)
        {
            return !lst.IsNullOrEmpty();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> lst)
        {
            return lst == null || !lst.Any();
        }
    }
}
