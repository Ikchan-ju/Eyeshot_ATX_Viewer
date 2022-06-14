using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    public class BasePanelType : PartType
    {
        public double thickness;
        public static bool visible = true;
        override public void setVisibility()
        {
            isVisible = visible;
        }
        public BasePanelType()
        {
            color = Color.Green;
        }
    }
}
