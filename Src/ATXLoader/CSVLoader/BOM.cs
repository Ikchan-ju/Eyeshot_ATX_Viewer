using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATXLoader
{
    public class BOM
    {
        public string SHIP;
        public string BLOCK;
        public string BLK;
        public int LEVEL_NO;
        public string ASSY;
        public string STAGE;
        public string SUBLOT;
        public string GRD;
        public string NEXT_ASSY;
        public string NEXT_STAGE;
        public string PAGENO;
        public string SEQNO;
        public string STORE_DATE;
        public string QTY;
        public string WGT;
        public string ERP_BLOCK;
        public string ERP_BLK;
        public TreeNode treeNode;

        public BOM(string[] bom, Dictionary<string, int> propertyIndex)
        {
            SHIP = bom[propertyIndex["SHIP"]];
            BLOCK = bom[propertyIndex["BLOCK"]];
            BLK = bom[propertyIndex["BLK"]];
            LEVEL_NO = bom[propertyIndex["LEVEL_NO"]].ToInt();
            ASSY = bom[propertyIndex["ASSY"]];
            STAGE = bom[propertyIndex["STAGE"]];
            SUBLOT = bom[propertyIndex["SUBLOT"]];
            GRD = bom[propertyIndex["GRD"]];
            NEXT_ASSY = bom[propertyIndex["NEXT_ASSY"]];
            NEXT_STAGE = bom[propertyIndex["NEXT_STAGE"]];
            PAGENO = bom[propertyIndex["PAGENO"]];
            SEQNO = bom[propertyIndex["SEQNO"]];
            STORE_DATE = bom[propertyIndex["STORE_DATE"]];
            QTY = bom[propertyIndex["QTY"]];
            WGT = bom[propertyIndex["WGT"]];
            ERP_BLOCK = bom[propertyIndex["ERP_BLOCK"]];
            ERP_BLK = bom[propertyIndex["ERP_BLK"]];
            treeNode = new TreeNode(ASSY);
        }
    }
}
