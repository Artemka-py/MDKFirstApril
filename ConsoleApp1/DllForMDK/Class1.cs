using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllForMDK
{
    public class Crypt
    {
        public static string Code_Message(string Value)
        {
            ushort sr = 0x0001;
            var ch = Value.ToArray();
            string newvalue = "";
            foreach (var c in ch)
            {
                newvalue += new_symp(c, sr);
            }

            return newvalue;
        }

        private static char new_symp(char value, ushort val)
        {
            value = (char) (value ^ val);
            return value;
        }
    }
}
