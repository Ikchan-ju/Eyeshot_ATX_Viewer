using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    public static class StringHelper
    {
        static public string AppendChar(this string str, char ch)
        {
            str += ch;
            return str;
        }
        // 공백으로 구분된 정수
        static public List<int> ToInts(this string str)
        {
            var doubles = str.ToDoubles();
            List<int> values = new List<int>();
            foreach(var d in doubles)
            {
                values.Add((int)d);
            }
            return values;
        }
        static public Segment ToSegment(this string str)
        {
            Segment seg = new Segment();
            var values = str.ToDoubles();
            // 6개의 값이 있어야 한다.
            if(values.Count != 6)
            {
                System.Diagnostics.Debug.Assert(false);
                return seg;
            }

            seg.ampitudePoint.X = values[0];
            seg.ampitudePoint.Y = values[1];
            seg.ampitudePoint.Z = values[2];

            seg.endPoint.X = values[3];
            seg.endPoint.Y = values[4];
            seg.endPoint.Z = values[5];

            return seg;
        }

        // string을 double로 변환
        // E가 포함될 수 있음
        static public double ToDouble(this string str)
        {
            if (str == "NaN")
                return 0;

            decimal d = decimal.Parse(str, NumberStyles.Number | NumberStyles.AllowExponent);

            return (double)d;
        }

        //string을 double list로 변환
        static public List<double> ToDoubles(this string str)
        {
            // 앞에 있는 공백 제거
            str = str.Trim();

            List<double> values = new List<double>();

            string curStr = "";
            char lastCh = ' ';
            foreach(var ch in str)
            {
                // 공백이나 -가 나올때까지 추가
                if (ch == ' ')
                {
                    if(curStr != "")
                    {
                        values.Add(curStr.ToDouble());
                    }

                    curStr = "";
                }
                    
                else if(ch == '-' && lastCh != 'E')
                {
                    if (curStr.Length == 0)
                    {
                        curStr = curStr.AppendChar(ch);
                    }
                    else {
                        values.Add(curStr.ToDouble());
                        curStr = "";
                        curStr = curStr.AppendChar(ch);
                    }
                    
                }
                else
                {
                    curStr = curStr.AppendChar(ch);
                }

                lastCh = ch;

                
            }

            if(curStr.Length > 0)
            {
                values.Add(curStr.ToDouble());
            }

            return values;
        }

        public static Point3D ToPoint3D(this string str)
        {
            List<double> values = str.ToDoubles();
            
            Point3D pt = new Point3D();
            if (values == null)
                return pt;
            if (values.Count > 0)
                pt.X = values[0];
            if (values.Count > 1)
                pt.Y = values[1];
            if (values.Count > 2)
                pt.Z = values[2];

            return pt;
        }
        public static int ToInt(this string str)
        {
            int num = 0;
            int.TryParse(str, out num);
            return num;
        }
    }
}
