using System;
using System.Collections.Generic;
using System.Linq;

namespace IntervalUtilityUnitTest {
    static class Helper {
        public static string ToStr<T>(this IEnumerable<T> arr)
            => string.Join(", ", arr.Select(ii => ii));

        public static bool Eq<T>(this IEnumerable<T> arr1, IEnumerable<T> arr2) {
            return arr1.Count() == arr2.Count()
                    && arr1.All(arr2.Contains)
                    && arr2.All(arr1.Contains);
        }
    }
}
