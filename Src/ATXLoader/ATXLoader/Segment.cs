using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    // segment 정보
    // ampitudePoint arc중간점(0, 0, 0)이면 segment가 직선임
    public class Segment
    {
        public Segment()
        {
            ampitudePoint = new Point3D();
            endPoint = new Point3D();
        }
        public Point3D ampitudePoint { get; set; }
        public Point3D endPoint { get; set; }

        internal bool IsLine()
        {
            if (ampitudePoint == null)
                return true;
            if (!ampitudePoint.X.IsEquals(0))
                return false;
            if (!ampitudePoint.Y.IsEquals(0))
                return false;
            if (!ampitudePoint.Z.IsEquals(0))
                return false;
            return true;
        }
    }
}
