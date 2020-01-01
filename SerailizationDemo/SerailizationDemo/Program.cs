using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SerailizationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialClassLib.Class1 c = new SerialClassLib.Class1();
            c.data = 46;
            BinaryFormatter bin = new BinaryFormatter();
            Stream stream = new FileStream(@"c:\serial.odt",FileMode.Create);
            bin.Serialize(stream,c);
            stream.Close();
            Console.WriteLine("Done");
            //bin.Deserialize(stream);
            //bin.Deserialize(stream);
        }
    }
}
