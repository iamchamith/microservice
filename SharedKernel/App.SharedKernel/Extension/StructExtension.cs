using System;
using System.Collections.Generic;
using System.Text;

namespace App.SharedKernel.Extension
{
    public static class StructExtension
    {
        public static bool IsZero(this int compare) {
            return compare == 0;
        }
        public static bool Is(this int compare,int compareWith)
        {
            return compare == compareWith;
        }
        public static bool IsNegative(this int compare) {
            return compare < 0;
        }
        public static bool IsZeroOrNegative(this int compare)
        {
            return compare <= 0;
        }
    }
}
