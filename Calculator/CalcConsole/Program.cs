using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            int.TryParse(args[1], out a);
            int.TryParse(args[2], out b);
            var oper = args[0];
            if (oper == "sum")
                Console.WriteLine($"{a} + {b} = {a + b}");
            Console.ReadKey();
        }
    }
}
