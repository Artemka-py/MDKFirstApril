using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllForMDK;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите что нить");
            string value = Console.ReadLine();
            Console.WriteLine("нажмите ентер для чего то");
            Console.ReadKey();
            Console.WriteLine(Crypt.Code_Message(value));
            Console.ReadKey();
        }
    }
}
