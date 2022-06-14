using ATXLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXViewer
{
    class ATXObjectProperties
    {
        ATXObject obj { get; set; }
        public ATXObjectProperties(ATXObject obj)
        {
            this.obj = obj;
        }



        [Category("Properties")]
        [DisplayName("Type")]
        public string Type
        {
            get
            {
                var str = obj.start_record_type.ToString();
                str = str.Replace("start_of_", "");
                str = str.ToUpper();
                return str;
            }
        }

        [Category("Properties")]
        [DisplayName("Production date")]
        public string ProductionDate
        {
            get
            {
                return obj.date_rec;
            }
        }

        [Category("Properties")]
        [DisplayName("Name")]
        public string Name
        {
            get
            {
                return obj.name;
            }
        }
    }

}
