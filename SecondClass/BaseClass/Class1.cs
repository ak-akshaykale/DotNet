using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass
{
    //class default internal
    public class Base
    {
        private int PRIVATE; //inside class only
        public int PUBLIC;  //anywhere
        protected int PROTECTED; //same class and subclasses
        internal int INTERNAL; //same class, same assembly
        protected internal int PROTECTED_INTERNAL; // same class, subclasses, same assembly
    }

}
