using ATXLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXViewer
{
    class ATXHoleGroupProperties
    {
        ATXGroup group;
        public ATXHoleGroupProperties(ATXGroup group)
        {
            this.group = group;
        }

        [Category("Properties")]
        [DisplayName("Type")]
        public string Type
        {
            get
            {
                return "Hole";
            }
        }

        [Category("Properties")]
        [DisplayName("Hole type")]
        public string HoleType
        {
            get
            {
                return group.hole_type;
            }
        }

        [Category("Properties")]
        [DisplayName("Subvolume id")]
        public string SubVolumeID
        {
            get
            {
                if(group.sub_seq.Count > 0)
                    return Math.Abs(group.sub_seq[0]).ToString();
                return "";
            }
        }
    }

}
