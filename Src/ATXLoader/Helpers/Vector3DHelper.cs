using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    static public class Vector3DHelper
    {
        static public bool IsParallel(this Vector3D vec1, Vector3D vec2)
        {
            if (!vec1.IsUnit)
                vec1.Normalize();
            if (!vec2.IsUnit)
                vec2.Normalize();
            double val = vec1.X * vec2.X + vec1.Y * vec2.Y + vec1.Z * vec2.Z;

            if (val - 1 != 0)
                return false;

            return true;
        }
        static public bool IsParallel(this Vector3D vec1, Vector3D vec2, double tor)
        {
            if (!vec1.IsUnit)
                vec1.Normalize();
            if (!vec2.IsUnit)
                vec2.Normalize();
            double val = vec1.X * vec2.X + vec1.Y * vec2.Y + vec1.Z * vec2.Z;

            if (Math.Abs(val) < 1 - tor)
                return false;

            return true;
        }
    }
}
