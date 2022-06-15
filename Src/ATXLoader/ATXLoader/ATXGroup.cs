using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Region = devDept.Eyeshot.Entities.Region;

namespace ATXLoader
{
    // group
    // panel에 속해 있는 객체를 의미한다.
    // flange, pillar, plate, doubling, panel-plate, bracket-plate 등..
    public class ATXGroup
    {
        public ATXGroup()
        {
            startpoint = new Point3D();
            segments = new List<Segment>();
            thickness_point = new Point3D();
            thickness_uvec = new Point3D();
            thickness_wvec = new Point3D();
            sub_seq = new List<int>();
            proftypandparam_real = new Point2D();
            codes = new List<string>();
        }

        // unique name
        public string GetUniqueName()
        {
            // 215 : triname
            return tri_name;
        }

        // 블럭No.
        public string GetBlockNumber()
        {
            // 201 : asslev1
            // 에서 마지막 글자 제외
            string str = this.assslev1;
            if (str == null || str == "")
                return "000";
            return str.Substring(0, str.Length - 1);
        }
        // 호선 넘버
        public string GetNumber()
        {
            // 321 : assm-name
            // 에서 /구분해서 첫번째 string에서 H를 제외한 string
            string str = this.asse_name;
            if (str == null || str == "")
                return "0000";
            var arr = str.Split('/');
            if (arr == null || arr.Length == 0)
                return "0000";
            return arr[0].Substring(1);
        }

        public string GetCategoryName(int idx)
        {
            var cate = GetCategories();
            if (cate == null || cate.Count <= idx)
                return "";
            return cate[idx];
        }

        // 부재명(categories) 리턴
        public List<string> GetCategories()
        {
            // 231 : assm-name
            // 207:posno 204 : asslev4
            // 를 차례대로 연결(assm-name은 / 로 구분)
            string str = $"{this.asse_name}/{this.posno}{this.assslev4}";

            // // 는 / 로 변경
            str = str.Replace("//", "/");
            var arr = str.Split('/');
            if (arr.Length == 0)
                return new List<string>() { asse_name };
            var categories = str.Split('/').ToList();

            // 첫번째는 호선번호
            if (categories.Count > 0)
                categories.RemoveAt(0);

            return categories;
        }
        public RecordTypeManager.RecordType start_record_type { get; set; } // group의 종류(시작 record type)
        public int seq_no { get; set; } //214
        public Entity entity { get; set; }
        public List<string> codes { get; set; }

        public Entity MakeEntityByRegion(Region r, bool entityAsMesh)
        {
            Entity ent = null;
            var dir = thickness_uvec.ToVector3D();
            try
            {
                if (entityAsMesh)
                    ent = r.ExtrudeAsMesh(dir, 0.001, Mesh.natureType.Smooth);
                else
                    ent = r.ExtrudeAsBrep(dir);
            }
            catch (Exception e)
            {
                ent = r.ExtrudeAsMesh(dir, 0.001, Mesh.natureType.Smooth);
            }

            ent.Color = GetColor();
            ent.ColorMethod = colorMethodType.byEntity;
            return ent;

        }
        // group의 entity를 만든다.
        public Entity MakeEntity()
        {
            var contour = MakeContour();
            if (contour == null)
                return null;

            var r = new Region(contour);
            return MakeEntityByRegion(r, false);
        }

        public Color GetColor()
        {
            if (start_record_type == RecordTypeManager.RecordType.start_of_plate)
                return Color.Green;
            else if (start_record_type == RecordTypeManager.RecordType.start_of_stiffener)
                return Color.Red;
            else if (start_record_type == RecordTypeManager.RecordType.start_of_pillar)
                return Color.Red;
            else if (start_record_type == RecordTypeManager.RecordType.start_of_bracket_plate)
                return Color.Cyan;
            else if (start_record_type == RecordTypeManager.RecordType.start_of_longitudinal_part)
                return Color.Red;
            else if (start_record_type == RecordTypeManager.RecordType.start_of_panel_plate)
                return Color.Green;
            else if (start_record_type == RecordTypeManager.RecordType.start_of_doubling)
                return Color.Red;

            throw new NotImplementedException();
        }
        // contour를 만든다.
        public CompositeCurve MakeContour()
        {
            if (startpoint == null)
                return null;


            List<ICurve> curves = new List<ICurve>();
            Point3D lastPoint = startpoint;
            foreach (var seg in segments)
            {
                if (seg.IsLine())
                {
                    Line line = new Line(lastPoint.ClonePoint3D(), seg.endPoint.ClonePoint3D());
                    curves.Add(line);
                }
                else
                {
                    Point3D midPoint = (lastPoint + seg.endPoint) / 2 + seg.ampitudePoint;
                    Arc arc = new Arc(lastPoint.ClonePoint3D(), midPoint, seg.endPoint.ClonePoint3D(), false);

                    curves.Add(arc);
                }
                lastPoint = seg.endPoint;
            }

            return new CompositeCurve(curves);
        }

        Vector3D normal
        {
            get
            {
                var nor = new Vector3D(thickness_uvec.X, thickness_uvec.Y, thickness_uvec.Z);
                nor.Normalize();
                return nor;

            }
        }

        // group과 entity를 연결
        public void Attach(Entity entity)
        {
            this.entity = entity;
            entity.EntityData = this;
        }

        public bool IsBody()
        {
            if (start_record_type == RecordTypeManager.RecordType.start_of_plate ||
                start_record_type == RecordTypeManager.RecordType.start_of_doubling ||
                start_record_type == RecordTypeManager.RecordType.start_of_panel_plate ||
                start_record_type == RecordTypeManager.RecordType.start_of_stiffener ||
                start_record_type == RecordTypeManager.RecordType.start_of_flange ||
                start_record_type == RecordTypeManager.RecordType.start_of_pillar ||
                start_record_type == RecordTypeManager.RecordType.start_of_bracket_plate ||
                start_record_type == RecordTypeManager.RecordType.start_of_longitudinal_part)
                return true;

            return false;
        }

        public bool IsHole()
        {
            if (start_record_type == RecordTypeManager.RecordType.start_of_hole)
                return true;

            return false;
        }

        public string tri_name { get ; set ; } // 215
        public string[] tri_name_split { get; set; } // 215
        public string asse_name { get; set; } // 231
        public string assslev1 { get; internal set; } // 201
        public string assslev2 { get; internal set; } // 202
        public string assslev3 { get; internal set; } // 203
        public string assslev4 { get; internal set; } // 204
        public int steelqual { get; internal set; } // 208
        public Point3D startpoint { get; internal set; } // 15
        public List<Segment> segments { get; set; } // 16
        public Point3D thickness_point { get; set; } // 240
        public Point3D thickness_uvec { get; set; } // 241
        public Point3D thickness_wvec { get; set; } //242
        public string hole_type { get; internal set; } //212
        public List<int> sub_seq { get; internal set; } // 213
        public int proftypandparam_int { get; set; } //200
        public Point2D proftypandparam_real { get; set; } // 200
        public int posno { get; internal set; } // 207
        public int stif_rep { get; internal set; } // 216
        public int macro_id { get; internal set; } // 218
        public string name_rec { get; internal set; } // 2, ATXGroup 내부의 변수는 아님..잘못된거같은데 확인 필요.
        public Part part { get; internal set; } // part 분류
    }
}
