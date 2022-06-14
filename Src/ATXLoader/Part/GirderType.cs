using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    public class GirderType : PartType
    {
        public double width;
        public double height;
        public double thickness;
        public static bool visible = true;
        override public void setVisibility()
        {
            isVisible = visible;
        }
        public GirderType()
        {
            color = Color.YellowGreen;
        }
    }
}
