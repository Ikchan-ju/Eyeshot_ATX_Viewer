using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    // object(panel, assembly를 load 한다)
    static public class ATXObjectLoader
    {
        static public ATXObject Load(StreamReader reader, RecordTypeManager.RecordType rt, IP ip)
        {
            // panel, longitudinal 등.. object는 타입만 구분되고, 모두 같은 방식이다.
            ATXObject obj = new ATXObject(rt);
            

            // end of object 가 나올때 까지 읽는다.
            while (!reader.EndOfStream)
            {
                RecordTypeManager.RecordType curRt;
                string data;
                if (!reader.ReadRecordTypeAndData(out curRt, out data, ip))
                    continue;

                // object의 끝이면 종료
                if (curRt == RecordTypeManager.RecordType.end_of_panel_assembly_curve)
                    break;

                if (curRt == RecordTypeManager.RecordType.date_rec)
                    obj.date_rec = data;
                else if (curRt == RecordTypeManager.RecordType.name_rec)
                    obj.name = data;
                else if (curRt == RecordTypeManager.RecordType.layer)
                    obj.layer = data.ToInt();
                else if (RecordTypeManager.IsStartOfGroup(curRt))
                {
                    // group의 시작이 나오면 group을 읽어와 새로운 group를 생성 및 추가한다. + group 추가 후 추가된 group에 part 매칭까지 진행

                    // group 읽기 시작
                    obj.groups.Add(LoadPanelGroup(reader, curRt, ip, data));

                    // part 매칭
                    PartTypeMatching(obj.groups[obj.groups.Count - 1]);
                }
                    
                else
                    throw new NotImplementedException();
                // object에 code를 넣고 code buffer를 clear한다.
                reader.PullReadLines(obj.codes);
            }

            // 이제 남은것은 panel의 마지막 코드임
            reader.PullReadLines(obj.codes);

            return obj;
        }

        private static void PartTypeMatching(ATXGroup atxGroup)
        {

            if (atxGroup.tri_name_split == null)
                return;
            if (atxGroup.tri_name_split.Length < 2)
                return;

            if (atxGroup.tri_name_split.Length == 2) // 배열의 길이가 2개인 경우 예시: B16P(블록번호)-BS1AP(큰 판때기 지칭. 이경우 주판)
            {
                string tempName = atxGroup.tri_name_split[1];

                var part = new Part(); // 매칭을 위한 part 객체 생성

                if (tempName.StartsWith("BS")) // base panel
                {
                    part.partType = new BasePanelType();
                }
                else if (tempName.StartsWith("FR")) // frame
                {
                    part.partType = new FrameType();
                }
                else if (tempName.StartsWith("GR")) // girder
                {
                    part.partType = new GirderType();
                }
                else if (tempName.StartsWith("BK")) // bracket
                {
                    part.partType = new BracketType();
                }
                else if (tempName.StartsWith("LG")) // 론지를 구별하려했으나, lg 시작하는거 없음. 지워도됨. 그냥 냄겨둠.
                {
                    part.partType = new LongiType();
                }
                else if (tempName.StartsWith("TT")) // 뚜껑
                {
                    part.partType = new TopPanelType();
                }
                else // 구별 못한 부재들은 emptyType이라고 정의해서 회색으로 디스플레이됨.
                {
                    part.partType = new EmptyType();
                }
                atxGroup.part = part; // 매칭된 파트를 atxGroup에 추가
            }
            else if (atxGroup.tri_name_split.Length == 3) // 배열의 길이가 3개인 경우 예시: B16P(블록번호)-BS1AP(큰 판때기 지칭. 이경우 주판)/S1P(소부재. 이경우 S라서 스티프너인 것으로 보이고, 주판에 붙은 스티프너라서 론지로 반펼함.)
            {
                string tempName = atxGroup.tri_name_split[2];

                var part = new Part(); // 매칭을 위한 part 객체 생성

                if (tempName.StartsWith("S") && atxGroup.tri_name_split[1].StartsWith("BS"))//base panel에 붙어있고, S로 시작(stiffner를 의미하는 것으로 보임)
                {
                    part.partType = new LongiType();
                } else if (tempName.StartsWith("P") && atxGroup.tri_name_split[1].StartsWith("GR"))//girder에 붙어있고, P로 시작(panel이나 plate를 의미하는 것으로 보임)
                {
                    part.partType = new FrameType();
                }
                else if (tempName.StartsWith("S") && atxGroup.tri_name_split[1].StartsWith("TT")) // 뚜껑에 붙은 론지
                {
                    part.partType = new TopPanelType();
                }
                else
            {
                part.partType = new EmptyType();
            }
                atxGroup.part = part; // 매칭된 파트를 atxGroup에 추가
            }
            else
            {
                var part = new Part();
                part.partType = new EmptyType();
                atxGroup.part = part;
            }

        }
        // panel의 group을 load한다.
        private static ATXGroup LoadPanelGroup(StreamReader reader, RecordTypeManager.RecordType rt, IP ip, string asse_name)
        {
            ATXGroup group = new ATXGroup();
            group.start_record_type = rt;


            // end of object 가 나올때 까지 읽는다.
            while (!reader.EndOfStream)
            {
                string data;
                if (!reader.ReadRecordTypeAndData(out rt, out data, ip))
                    continue;

                // group의 끝이면 종료
                if (RecordTypeManager.IsEndOfGroup(rt))
                    break; ;

                if (rt == RecordTypeManager.RecordType.seq_no)
                    group.seq_no = data.ToInt();
                else if (rt == RecordTypeManager.RecordType.proftypandparam)
                {
                    var strings = data.Split(' ');
                    if (strings.Length > 0)
                        group.proftypandparam_int = strings[0].ToInt();
                    if (strings.Length > 2)
                    {
                        group.proftypandparam_real = new devDept.Geometry.Point2D();
                        group.proftypandparam_real.X = strings[1].ToDouble();
                        group.proftypandparam_real.Y = strings[2].ToDouble();
                    }

                }
                else if (rt == RecordTypeManager.RecordType.triname)
                {
                    group.tri_name = data;
                    group.tri_name_split = data.Split('-','/');
                }
                else if (rt == RecordTypeManager.RecordType.asse_name)
                    group.asse_name = data;
                else if (rt == RecordTypeManager.RecordType.assslev1)
                    group.assslev1 = data;
                else if (rt == RecordTypeManager.RecordType.assslev2)
                    group.assslev2 = data;
                else if (rt == RecordTypeManager.RecordType.assslev3)
                    group.assslev3 = data;
                else if (rt == RecordTypeManager.RecordType.assslev4)
                    group.assslev4 = data;
                else if (rt == RecordTypeManager.RecordType.steelqual)
                    group.steelqual = data.ToInt();
                else if (rt == RecordTypeManager.RecordType.startpoint)
                    group.startpoint = data.ToPoint3D();
                else if (rt == RecordTypeManager.RecordType.segment)
                    group.segments.Add(data.ToSegment());
                else if (rt == RecordTypeManager.RecordType.thickness_point)
                    group.thickness_point = data.ToPoint3D();
                else if (rt == RecordTypeManager.RecordType.thickness_uvec)
                    group.thickness_uvec = data.ToPoint3D();
                else if (rt == RecordTypeManager.RecordType.thickness_wvec)
                    group.thickness_wvec = data.ToPoint3D();
                else if (rt == RecordTypeManager.RecordType.hole_type)
                    group.hole_type = data;
                else if (rt == RecordTypeManager.RecordType.sub_seq)
                    group.sub_seq = data.ToInts();
                else if (rt == RecordTypeManager.RecordType.posno)
                    group.posno = data.ToInt();
                else if (rt == RecordTypeManager.RecordType.stif_rep)
                    group.stif_rep = data.ToInt();
                else if (rt == RecordTypeManager.RecordType.macro_id)
                    group.macro_id = data.ToInt();
                else if (rt == RecordTypeManager.RecordType.name_rec)
                    group.name_rec = data;
                else
                    throw new NotImplementedException();

            }

            reader.PullReadLines(group.codes);

            return group;
        }
    }
}
