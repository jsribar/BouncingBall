using System;
using System.Collections.Generic;
using System.Text;

namespace Vsite.Pood.BouncingBall
{
    static class DoubleExtensions
    {
        public static bool IsAllmostEqual(this double value1, double value2, long units)
        {
            if (value1 == value2)
                return true;
            long lValue1 = BitConverter.DoubleToInt64Bits(value1);
            long lValue2 = BitConverter.DoubleToInt64Bits(value2);

            // If the signs are different, return false except for +0 and -0.
            if ((lValue1 >> 63) != (lValue2 >> 63))
                return value1 == value2;

            long diff = Math.Abs(lValue1 - lValue2);
            return diff <= units;
        }

        public static bool IsAllmostEqual(this double value1, double value2)
        {
            if (value1 == value2)
                return true;
            return Math.Abs(value1 - value2) < 1e-5;
        }
        
        public static bool IsWholePartEqual(this double value1, double value2)
        {
            value1 = Math.Truncate(value1);
            value2 = Math.Truncate(value2);

            return value1 == value2;
        }
    }
}
