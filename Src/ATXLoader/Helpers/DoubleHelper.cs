using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    static public class DoubleHelper
    {
        static public bool IsEquals(this double value, double otherValue, double tol = 0.00001)
        {
            if (Math.Abs(value - otherValue) <= tol)
                return true;
            return false;
        }
    }
}
