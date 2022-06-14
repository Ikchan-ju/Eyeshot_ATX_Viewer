using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    static public class StreamReaderHelper
    {
        // 지금까지 읽은 line을 순서대로 보관하는 버퍼
        static List<string> readLinesBuffer = new List<string>();

        // 지금까지 읽은 line을 리턴하고 buffer는 clear한다.
        static public void PullReadLines(this StreamReader reader, List<string> returnCodes)
        {
            returnCodes.AddRange(readLinesBuffer);
            readLinesBuffer.Clear();
        }
        
        static public void ClearReadLines(this StreamReader reader)
        {
            StreamReaderHelper.readLinesBuffer.Clear();
        }

        static public string GetLastReadLine(this StreamReader reader)
        {
            if (readLinesBuffer.Count == 0)
                return null;
            return readLinesBuffer[readLinesBuffer.Count - 1];
        }

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        // recordtype과 data부분을 읽는다.
        static public bool ReadRecordTypeAndData(this StreamReader reader, out RecordTypeManager.RecordType rt, out string data, IP ip)
        {
            string line = reader.ReadLine();
            StreamReaderHelper.readLinesBuffer.Add(line);
            line = line.Trim();
            // line이 공백이 아닐때 까지 읽는다.
            while (line == "")
            {
                line = reader.ReadLine();
                StreamReaderHelper.readLinesBuffer[StreamReaderHelper.readLinesBuffer.Count - 1] = line;
                line = line.Trim();
            }

            string rtString = "";

            // 시작이 15, 16인 경우 좌표인데 이 때는 ip 설정에 따라 자리수대로 읽어야함.
            if (ip != null && (line.StartsWith("15") || line.StartsWith("16")))
            {
                int len = ip.ext_prec ? 21 : 13;
                rtString = line.Substring(0, 2);
                line = line.Remove(0, 2);

                var strings = Split(line, len);
                var sb = new StringBuilder();
                foreach(var str in strings)
                {
                    if (sb.Length > 0)
                        sb.Append(" ");
                    sb.Append(str);
                }
                data = sb.ToString();

            }
            else
            {
                int idx = line.IndexOf(' ');
                rtString = line;
                if (idx > -1)
                {
                    rtString = line.Substring(0, idx);
                    data = line.Substring(idx + 1, line.Length - idx - 1);
                    data = data.Trim();
                }
                else
                {
                    rtString = line;
                    data = "";
                }

                // data에서 연속된 공백은 1개만 남긴다.
                while (true)
                {
                    var newData = data.Replace("  ", " ");
                    if (newData.Equals(data))
                        break;
                    data = newData;
                }
            }
            

            rt = RecordTypeManager.GetrecordType(rtString);
            return rt == RecordTypeManager.RecordType.unknown ? false : true;
        }
    }
}
