using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERFACE
{
    class Program
    {
        static void Main(string[] args)
        {
            MasterOperation master1 = new MasterOperation();
            master1.open();
            master1.connect();
            master1.delete();
            master1.disconnect();
            master1.read();
            master1.close();

            ((IFileoperation)master1).close();

            IDboperation iDb = new MasterOperation();
            iDb.connect();
            iDb.read();
            iDb.disconnect();

            IFileoperation iFo = new MasterOperation();
            iFo.open();
            iFo.read();
            iFo.delete();
            iFo.close();


            Console.ReadLine();


        }
    }

    interface IFileoperation
    {
        void open();
        void read();
        void close();
        void delete();

    }

    interface IDboperation
    {
        void connect();
        void disconnect();
        void read();
    }
    class MasterOperation : IFileoperation, IDboperation
    {
        public void close()
        {
            Console.WriteLine("File.close");
        }

        public void delete()
        {
            Console.WriteLine("File.delete");
        }

        public void open()
        {
            Console.WriteLine("File.open");
        }

        public void read()
        {
            Console.WriteLine("File.read");
        }

        public void connect()
        {
            Console.WriteLine("DB.Connect");
        }

        public void disconnect()
        {
            Console.WriteLine("DB.Disconnect");
        }

        void IDboperation.read()
        {
            Console.WriteLine("Db.read");
        }
    }

}
