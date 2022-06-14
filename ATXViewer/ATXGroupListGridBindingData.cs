using ATXLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXViewer
{

    public class ATXGroupListGridBindingData
    {
        ATXGroup group;
        public ATXGroupListGridBindingData(ATXGroup group)
        {
            this.group = group;
            this.Visible = true;
        }

        public ATXGroup GetGroup() { return group; }
        public bool Visible { get; set; }
        public string 부재명 { get { return group.GetCategoryName(0); } }
        public string p1 { get { return group.GetCategoryName(1); } }
        public string p2 { get { return group.GetCategoryName(2); } }
        public string p3 { get { return group.GetCategoryName(3); } }
        public string p4 { get { return group.GetCategoryName(4); } }


        public string Unique_Name
        {
            get
            {
                return group.GetUniqueName();
            }
        }

        public string 호선넘버
        {
            get
            {
                return group.GetNumber();
            }
        }


        public string 블록No
        {
            get
            {
                return group.GetBlockNumber();
            }
        }
    }
}
