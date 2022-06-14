using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    public class PartType
    {
        public string partTypeName;
        public Image shape;
        public Color color = Color.LightGray;
        public bool isVisible = true;
        virtual public void setVisibility()
        {
        }
    }
}
