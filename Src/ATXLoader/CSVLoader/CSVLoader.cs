using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    public class CSVLoader
    {
        string fileName;
        Dictionary<string, int> propertyIndex = new Dictionary<string, int>();
        public List<BOM> bomData;

        public CSVLoader(string fileName) // 지정 경로의 csv 파일을 읽어와 bom객체의 리스트로 변환.
        {
            this.fileName = fileName;

            StreamReader sr = new StreamReader(fileName);
            bomData = new List<BOM>();

            {
                string temp = sr.ReadLine();
                temp = temp.Replace("\"", "");
                string[] deliminated = temp.Split(',');
                for(int i = 1; i < deliminated.Length; i++)
                {
                    propertyIndex.Add(deliminated[i], i);
                }
            }
            while (!sr.EndOfStream)
            {
                string temp = sr.ReadLine();
                temp = temp.Replace("\"", "");
                string[] deliminated = temp.Split(',');

                bomData.Add(new BOM(deliminated, propertyIndex));
            }
        }
    }
}
