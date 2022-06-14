using ATXLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXViewer
{
    public class ATXObjectParameterGridBindingData
    {
        ATXObject obj;
        public ATXObjectParameterGridBindingData(ATXObject obj)
        {
            this.obj = obj;
        }

        public string Code
        {
            get
            {
                var codes = obj.GetAllCodes();
                StringBuilder sb = new StringBuilder();
                codes.ForEach(c => sb.AppendLine(c));
                return codes.ToString();
            }
            

        }
    }
}
