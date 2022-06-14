using devDept.Eyeshot;
using devDept.Eyeshot.Labels;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    public class Loader : WorkUnit
    {
        // load된 object들
        public List<ATXObject> objects = new List<ATXObject>();
        public string fileName { get; set; }
        public bool entityAsMesh { get; set; }

        
        public Loader(string fileName)
        {
            this.fileName = fileName;
            entityAsMesh = true;
        }
        protected override void DoWork(BackgroundWorker worker, DoWorkEventArgs doWorkEventArgs)
        {
            UpdateProgress(1, 3, "Loading...", worker, true);
            // load
            Load(fileName);

            UpdateProgress(2, 3, "Making entities...", worker, true);
            // add 
            MakeEntities(entityAsMesh);

            UpdateProgress(3, 3, "Rendering...", worker, true);
        }

      
        public bool Load(string fileName)
        {
            // 파일이 없으면 리턴
            if (!System.IO.File.Exists(fileName))
                return false;

            // 파일을 연다.
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            if (stream == null)
                return false;
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
            if (reader == null)
                return false;

            // todo : IP 파일도 읽어야 함.
            IP ip = new IP();

            while (!reader.EndOfStream)
            {
                RecordTypeManager.RecordType rt;
                string data;
                
                if (!reader.ReadRecordTypeAndData(out rt, out data, ip))
                    continue;

                // object의 시작인지?
                // 여기서는 object의 시작만 나와야 함.
                if (RecordTypeManager.IsStartOfObject(rt))
                {
                    var obj = ATXObjectLoader.Load(reader, rt, ip);
                    if (obj == null)
                        continue;

                    objects.Add(obj);
                }
                else
                {
                    System.Diagnostics.Debug.Assert(false);
                }
            }

            reader.Close();
            stream.Close();

            return true;
        }

        // 좌표 정보를 표시한다.
        public void ShowSegmentInfo(Model model)
        {
            model.ActiveViewport.Labels.Clear();

            foreach (var ele in objects)
            {
                ATXObject obj = ele as ATXObject;
                if (obj == null)
                    continue;

                ATXObject panel = obj as ATXObject;
                if (panel == null)
                    continue;

                System.Drawing.Font font = new System.Drawing.Font("Arial", 10);
                var offset = new Vector2D(0, 30);
                foreach (var g in panel.groups)
                {
                    foreach(var seg in g.segments)
                    {
                        LeaderAndText lt = new LeaderAndText(seg.endPoint, $"EP({seg.endPoint})", font, Color.Black, offset);
                        model.ActiveViewport.Labels.Add(lt);

                        if(!seg.IsLine())
                        {
                            lt = new LeaderAndText(seg.endPoint, $"AP({seg.ampitudePoint})", font, Color.Red, offset);
                            model.ActiveViewport.Labels.Add(lt);
                        }
                        
                    }
                }
                
            }
        }

        public void MakeEntities(bool entityAsMesh)
        {
            foreach (var ele in objects)
            {
                ATXObject obj = ele as ATXObject;
                if (obj == null)
                    continue;
                obj.MakeEntities(entityAsMesh);
            }
        }

        // load 한 element를 model에 객체로 집어 넣는다.
        public void AddToModel(Model model)
        {
            //model.Entities.Clear();
            foreach(var ele in objects)
            {
                ATXObject obj = ele as ATXObject;
                if (obj == null)
                    continue;
                if (obj.entities == null)
                    continue;

                //entities.AddRange(obj.entities);
                model.Entities.AddRange(obj.entities);
            }

            foreach (var ent in model.Entities)
            {
                var atxGroup = ent.EntityData as ATXGroup;
                if (atxGroup == null)
                    continue;
                var part = atxGroup.part as Part;
                if (part == null)
                    continue;

                ent.Color = part.partType.color;
                ent.ColorMethod = devDept.Eyeshot.Entities.colorMethodType.byEntity;


                if (part.partType is EmptyType)
                {
                    ent.Visible = EmptyType.visible;
                }
                //model.Entities.Regen();
                //model.Invalidate();
            }
        }

        
    }
}
