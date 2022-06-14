using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXLoader
{
    public class Part
    {
        public string partName;
        public PartType partType;
        public Entity entity;

        public Part()
        {
            partType = new PartType();
        }
    }
}
