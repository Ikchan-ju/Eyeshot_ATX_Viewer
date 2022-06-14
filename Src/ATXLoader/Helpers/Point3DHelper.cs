using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    static public class Point3DHelper
    {
        static public Vector3D ToVector3D(this Point3D pt)
        {
            return new Vector3D(pt.X, pt.Y, pt.Z);
        }

        static public Point3D ClonePoint3D(this Point3D pt)
        {
            return pt.Clone() as Point3D;
        }
    }
}
