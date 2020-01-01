using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SystemDriveFileHandling
{
    class NameMaster : ISerializable
    {
        private int MASTER_CODE;
       
        public string Name { set; get; }
        public string Code { set; get; }
        public string Runner { set; get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo info = new DriveInfo(@"C:\.netak\filesample");
            Console.WriteLine("Name of Drive:: " + info.Name); //info.RootDirectory
            Console.WriteLine("Space::"+info.AvailableFreeSpace);
            Console.WriteLine("Format of Drive:: "+info.DriveFormat);
            Console.WriteLine("Type of Drive(fix/not):: "+info.DriveType);
            Console.WriteLine("type:: "+info.GetType().Assembly); 
            Console.WriteLine("type:: "+info);

            FileInfo file = new FileInfo(@"C:\.netak\filesample\abc.txt");
            FileStream fstream = new FileStream(@"C:\.netak\filesample\abc.txt", FileMode.Create);
            Console.WriteLine(file.GetType());


            BinaryFormatter f = new BinaryFormatter();
           // f.Serialize(file.GetType().Assembly);
            Console.ReadLine();
            

        }
    }
}
