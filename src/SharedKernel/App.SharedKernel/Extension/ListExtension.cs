using System.Collections.Generic;

namespace App.SharedKernel.Extension
{
    public static class ListExtension
    {
        public static bool IsNullOrZero<T>(this List<T> items) {

            return items.IsNull() || items.Count == 0;
        }
    }
}
