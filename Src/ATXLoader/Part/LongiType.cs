using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    public class LongiType : PartType
    {
        public double length;
        public static bool visible = true;
        override public void setVisibility()
        {
            isVisible = visible;
        }
        public LongiType()
        {
            color = Color.Red;
        }
    }
}
