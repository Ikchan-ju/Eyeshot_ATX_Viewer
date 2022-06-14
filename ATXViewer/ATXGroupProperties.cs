using ATXLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATXViewer
{
    class ATXGroupProperties
    {
        ATXGroup group;
        public ATXGroupProperties(ATXGroup group)
        {
            this.group = group;
        }

        public string Code
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                group.codes.ForEach(str => sb.AppendLine(str));
                return sb.ToString();
            }
        }
        //[Category("Properties")]
        //[DisplayName("Type")]
        //public string Type
        //{
        //    get
        //    {
        //        var str = group.start_record_type.ToString();
        //        str = str.Replace("start_of_", "");
        //        str = str.ToUpper();
        //        return str;
        //    }
        //}

        //[Category("Properties")]
        //[DisplayName("Volume id")]
        //public string VolumeID
        //{
        //    get
        //    {
        //        return group.seq_no.ToString();
        //    }
        //}

        //[Category("Properties")]
        //[DisplayName("Tribon id")]
        //public string TribonID
        //{
        //    get
        //    {
        //        return group.tri_name;
        //    }
        //}

        //[Category("Properties")]
        //[DisplayName("Assembly name")]
        //public string AssemblyName
        //{
        //    get
        //    {
        //        return group.asse_name;
        //    }
        //}

        //[Category("Properties")]
        //[DisplayName("Assembly level1")]
        //public string AssemblyLevel1
        //{
        //    get
        //    {
        //        return group.assslev1;
        //    }
        //}

        //[Category("Properties")]
        //[DisplayName("Assembly level4")]
        //public string AssemblyLevel4
        //{
        //    get
        //    {
        //        return group.assslev4;
        //    }
        //}
        //[Category("Properties")]
        //[DisplayName("Steel quality")]
        //public string SteelQuality
        //{
        //    get
        //    {
        //        return group.steelqual.ToString();
        //    }
        //}





    }
}
