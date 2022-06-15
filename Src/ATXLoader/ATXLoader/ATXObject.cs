using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    // panel이나 assembly의 base
    public class ATXObject
    {
        public RecordTypeManager.RecordType start_record_type { get; set; }
        public string date_rec { get; set; } //230
        public string name { get; internal set; } // 2

        // group을 포함한 모든 코드를 리턴
        public List<string> GetAllCodes()
        {
            List<string> allCodes = new List<string>();

            allCodes.AddRange(codes);
            groups.ForEach(g => allCodes.InsertRange(allCodes.Count - 1, g.codes));
            return allCodes;
        }

        public int layer { get; internal set; } //9
        public List<ATXGroup> groups { get; set; } // 717XX
        public EntityList entities { get; set; }

        // object의 모든 코드
        public List<string> codes { get; set; }

        public ATXObject(RecordTypeManager.RecordType start_record_type)
        {
            this.start_record_type = start_record_type;
            groups = new List<ATXGroup>();
            codes = new List<string>();
        }

        public override string ToString()
        {
            return name;
        }

        // panel의 entity를 만들어서 리턴
        public bool MakeEntities(bool entityAsMesh)
        {
            bool byRegion = true;
            if (byRegion)
            {
                MakeEntities_ByRegion(entityAsMesh);
            }
            else
            {
                MakeEntities_ByBrep();
                
            }


            return true;
        }

        private void MakeEntities_ByBrep()
        {
            entities = new EntityList();
            Entity body = null;
            foreach (var group in groups)
            {
                Entity entity = group.MakeEntity();
                if (entity == null)
                    continue;

                if (group.IsHole())
                {
                    if (body is Brep && entity is Brep)
                    {
                        var result = Brep.Difference((Brep)body, (Brep)entity);
                        if (result != null)
                        {
                            if (result.Length > 0)
                                body = result[0];
                            else
                                body = null;
                        }
                    }
                }
                else if (group.IsBody())
                {
                    body = entity;
                }
            }

            if (body != null)
                entities.Add(body);
        }

        private void MakeEntities_ByRegion(bool entityAsMesh)
        {
            entities = new EntityList();

            for (int i = 0; i < groups.Count; ++i)
            {
                var group = groups[i];
                bool isBody = group.IsBody();
                if (!isBody)
                    continue;

                List<ICurve> contours = new List<ICurve>();
                var contour = group.MakeContour();
                if (contour != null)
                    contours.Add(contour);

                // 연속되는 hole을 모두 추가
                var nextI = i;
                for (int j = i + 1; j < groups.Count; ++j)
                {
                    nextI = j - 1;
                    var holeGroup = groups[j];
                    if (!holeGroup.IsHole())
                        break;
                    var holeContour = holeGroup.MakeContour();
                    if (holeContour != null)
                    {
                        // hole도 일단 객체로 추가한다.
                        var holeRegion = new Region(holeContour);
                        var holeEntity = group.MakeEntityByRegion(holeRegion, entityAsMesh);
                        if (holeEntity != null)
                        {
                            holeEntity.LayerName = "Hole";
                            holeGroup.Attach(holeEntity);
                            entities.Add(holeEntity);
                        }
                        contours.Add(holeContour);
                    }
                }

                i = nextI;

                // 추가
                if (contours.Count == 0)
                {
                }
                else if (group.thickness_uvec == new Point3D(0, 0, 0))
                {
                    foreach (var con in contours)
                    {
                        if (con is CompositeCurve)
                        {
                            var comp = con as CompositeCurve;
                            foreach (var item in comp.CurveList)
                            {
                                var curve = item as ICurve;
                                var plane = new Plane(curve.StartPoint, curve.StartTangent);
                                Region section = new Region(new Circle(plane, 10));

                                var mesh = section.SweepAsMesh(curve, 0.001);
                                if (mesh == null)
                                    continue;
                                
                                group.Attach(mesh);
                                entities.Add(mesh);

                            }
                        }
                        else
                        {

                        }

                    }

                }
                else
                {
                    Region r = new Region(contours);
                    var entity = group.MakeEntityByRegion(r, entityAsMesh);
                    if (entity != null)
                    {
                        group.Attach(entity);
                        entities.Add(entity);
                    }
                }
            }
        }
    }
}
