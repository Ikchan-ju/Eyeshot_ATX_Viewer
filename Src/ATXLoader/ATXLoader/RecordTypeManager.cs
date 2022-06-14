using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    static public class RecordTypeManager
    {
        public enum RecordType
        {
            unknown, proftypandparam, assslev1, assslev2, assslev3, assslev4, surftreat, destin, posno,
            steelqual, endcut_type, cutout_type, notch_type, hole_type, sub_seq,
            seq_no, stif_rep, cutout_notch_point, macro_id, thickness_point, 
            thickness_uvec, thickness_wvec, startpoint, segment, date_rec, name_rec,
            asse_name, triname, start_of_panel, end_of_panel_assembly_curve, start_of_assembly,
            start_of_unknown_object, start_of_curve, start_of_longitudinal,
            end_of_longitudinal, start_of_longitudinal_part, end_of_longitudinal_part,
            start_of_transversal, end_of_transversal, start_of_transversal_part, 
            end_of_transversal_part, start_of_plate, start_of_doubling, start_of_panel_plate,
            start_of_stiffener, start_of_flange, start_of_pillar, start_of_bracket_plate, 
            end_of_plate, end_of_doubling, end_of_panel_plate, end_of_stiffener, end_of_flange,
            end_of_pillar, end_of_bracket_plate, start_of_clip, end_of_clip, start_of_endcut, 
            end_of_endcut, start_of_notch, end_of_notch, start_of_hole, end_of_hole, layer
        }

       

        // object의 시작인지?
        // panel 또는 assembly의 시작인지?
        public static bool IsStartOfObject(RecordType rt)
        {
            if (rt == RecordType.start_of_panel ||
                rt == RecordType.start_of_unknown_object ||
                rt == RecordType.start_of_assembly ||
                rt == RecordType.start_of_longitudinal ||
                rt == RecordType.start_of_transversal)
                return true;

            return false;
        }

        // group의 시작인지?
        // 71??? 인지?
        public static bool IsStartOfGroup(RecordType rt)
        {
            if (rt == RecordType.start_of_longitudinal)
                return true;
            if (rt == RecordType.start_of_longitudinal_part)
                return true;
            if (rt == RecordType.start_of_transversal)
                return true;
            if (rt == RecordType.start_of_transversal_part)
                return true;
            if (rt == RecordType.start_of_plate)
                return true;
            if (rt == RecordType.start_of_doubling)
                return true;
            if (rt == RecordType.start_of_panel_plate)
                return true;
            if (rt == RecordType.start_of_stiffener)
                return true;
            if (rt == RecordType.start_of_flange)
                return true;
            if (rt == RecordType.start_of_pillar)
                return true;
            if (rt == RecordType.start_of_bracket_plate)
                return true;
            if (rt == RecordType.start_of_clip)
                return true;
            if (rt == RecordType.start_of_endcut)
                return true;
            if (rt == RecordType.start_of_notch)
                return true;
            if (rt == RecordType.start_of_hole)
                return true;

            return false;
        }

        // group의 끝인지?
        internal static bool IsEndOfGroup(RecordType rt)
        {
            if (rt == RecordType.end_of_longitudinal)
                return true;
            if (rt == RecordType.end_of_longitudinal_part)
                return true;
            if (rt == RecordType.end_of_transversal)
                return true;
            if (rt == RecordType.end_of_transversal_part)
                return true;
            if (rt == RecordType.end_of_plate)
                return true;
            if (rt == RecordType.end_of_doubling)
                return true;
            if (rt == RecordType.end_of_panel_plate)
                return true;
            if (rt == RecordType.end_of_stiffener)
                return true;
            if (rt == RecordType.end_of_flange)
                return true;
            if (rt == RecordType.end_of_pillar)
                return true;
            if (rt == RecordType.end_of_bracket_plate)
                return true;
            if (rt == RecordType.end_of_clip)
                return true;
            if (rt == RecordType.end_of_endcut)
                return true;
            if (rt == RecordType.end_of_notch)
                return true;
            if (rt == RecordType.end_of_hole)
                return true;

            return false;
        }

        static public Dictionary<int, RecordType> recordTypes= null;

        private static void InitRecordTypes()
        {
            recordTypes = new Dictionary<int, RecordType>();

            
            recordTypes.Add(200, RecordType.proftypandparam);
            recordTypes.Add(201, RecordType.assslev1);
            recordTypes.Add(202, RecordType.assslev2);
            recordTypes.Add(203, RecordType.assslev3);
            recordTypes.Add(204, RecordType.assslev4);
            recordTypes.Add(205, RecordType.surftreat);
            recordTypes.Add(206, RecordType.destin);
            recordTypes.Add(207, RecordType.posno);
            recordTypes.Add(208, RecordType.steelqual);
            recordTypes.Add(209, RecordType.endcut_type);
            recordTypes.Add(210, RecordType.cutout_type);
            recordTypes.Add(211, RecordType.notch_type);
            recordTypes.Add(212, RecordType.hole_type);
            recordTypes.Add(213, RecordType.sub_seq);
            recordTypes.Add(214, RecordType.seq_no);
            recordTypes.Add(216, RecordType.stif_rep);
            recordTypes.Add(217, RecordType.cutout_notch_point);
            recordTypes.Add(218, RecordType.macro_id);
            recordTypes.Add(240, RecordType.thickness_point);
            recordTypes.Add(241, RecordType.thickness_uvec);
            recordTypes.Add(242, RecordType.thickness_wvec);
            recordTypes.Add(15, RecordType.startpoint);
            recordTypes.Add(16, RecordType.segment);
            recordTypes.Add(230, RecordType.date_rec);
            recordTypes.Add(2, RecordType.name_rec);
            recordTypes.Add(231, RecordType.asse_name);
            recordTypes.Add(215, RecordType.triname);
            recordTypes.Add(1701, RecordType.start_of_panel);
            recordTypes.Add(99, RecordType.end_of_panel_assembly_curve);
            recordTypes.Add(1735, RecordType.start_of_assembly);
            recordTypes.Add(1731, RecordType.start_of_longitudinal); // 메뉴얼에 없는 레코드 타입이다.1731이 71731로 오기된듯. (객체의시작인것 같기는 함)
            recordTypes.Add(1741, RecordType.start_of_curve);
            //recordTypes.Add(71731, RecordType.start_of_longitudinal);   // 원래 1731인데, 메뉴얼에 71731로 오기된듯
            //recordTypes.Add(70731, RecordType.end_of_longitudinal);     // 원래 없는데, 메뉴얼에 71731이 들어오면서 잘못 작성된듯.(object의 끝은 99로 동일하기 때문)
            recordTypes.Add(71732, RecordType.start_of_longitudinal_part);
            recordTypes.Add(70732, RecordType.end_of_longitudinal_part);
            recordTypes.Add(71733, RecordType.start_of_transversal);
            recordTypes.Add(70733, RecordType.end_of_transversal);
            recordTypes.Add(71734, RecordType.start_of_transversal_part);
            recordTypes.Add(70734, RecordType.end_of_transversal_part);
            recordTypes.Add(71707, RecordType.start_of_plate);
            recordTypes.Add(71708, RecordType.start_of_doubling);
            recordTypes.Add(71702, RecordType.start_of_panel_plate);
            recordTypes.Add(71704, RecordType.start_of_stiffener);
            recordTypes.Add(71705, RecordType.start_of_flange);
            recordTypes.Add(71706, RecordType.start_of_pillar);
            recordTypes.Add(71722, RecordType.start_of_bracket_plate);
            recordTypes.Add(70707, RecordType.end_of_plate);
            recordTypes.Add(70708, RecordType.end_of_doubling);
            recordTypes.Add(70702, RecordType.end_of_panel_plate);
            recordTypes.Add(70704, RecordType.end_of_stiffener);
            recordTypes.Add(70705, RecordType.end_of_flange);
            recordTypes.Add(70706, RecordType.end_of_pillar);
            recordTypes.Add(70722, RecordType.end_of_bracket_plate);
            recordTypes.Add(71724, RecordType.start_of_clip);
            recordTypes.Add(70724, RecordType.end_of_clip);
            recordTypes.Add(71750, RecordType.start_of_endcut);
            recordTypes.Add(70750, RecordType.end_of_endcut);
            recordTypes.Add(71752, RecordType.start_of_notch);
            recordTypes.Add(70752, RecordType.end_of_notch);
            recordTypes.Add(71703, RecordType.start_of_hole);
            recordTypes.Add(70703, RecordType.end_of_hole);
            recordTypes.Add(9, RecordType.layer);

        }
        public static RecordType GetrecordType(string str)
        {
            if (recordTypes == null)
                InitRecordTypes();

            int num = -1;
            if (!int.TryParse(str, out num))
                return RecordType.unknown;

            if (!recordTypes.ContainsKey(num))
            {
                System.Diagnostics.Debug.Assert(false);
                return RecordType.unknown;
            }

            return recordTypes[num];
        }

    }
}
