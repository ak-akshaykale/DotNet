using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialClassLib
{
    [Serializable]
    public class Class1
    {
        int private_data;
        public int data;

        [XmlElement]
        public int P1 { set; get; }
    }
}
