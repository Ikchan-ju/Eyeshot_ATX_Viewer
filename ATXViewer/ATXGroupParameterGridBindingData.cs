using ATXLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXViewer
{
    public class ATXGroupParameterGridBindingData
    {
        ATXGroup group;
        public ATXGroupParameterGridBindingData(ATXGroup group)
        {
            this.group = group;
        }

        public string Code
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                group.codes.ForEach(code => sb.AppendLine(code));

                var str = sb.ToString();
                return str;
            }
        }
    }

}
