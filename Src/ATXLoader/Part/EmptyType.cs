using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    public class EmptyType : PartType
    {
        public static bool visible = true;
        override public void setVisibility()
        {
            isVisible = visible;
        }
        public EmptyType()
        {
            color = Color.Gray;
        }
    }
}
