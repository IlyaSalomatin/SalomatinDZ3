using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SalomatinDZ3
{
    class Program
    {
        public static void Main(string[] args)
        {

            Menu supportObject = new Menu();
            supportObject.TypeSerializ();
            supportObject.Deserialize();
            supportObject.StartProgram();

        }
        
    }

}
