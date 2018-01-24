using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcLibrary;

namespace CalcConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                int.TryParse(args[1], out int a);
                int.TryParse(args[2], out int b);
                string oper = args[0];
                if (oper == "sum")
                    Console.WriteLine($"{a} + {b} = {a + b}");
            }

            Calc calc = new Calc();
            while (true)
            {
                Console.WriteLine("Список доступных операций:");
                foreach (var item in calc.GetOperations())
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Для выхода из программы нажмите e");
                Console.Write("Ввод: ");

                string oper = Console.ReadLine();
                if(oper == "e")
                {
                    Environment.Exit(0);
                }

                Console.WriteLine("Введиете переменные: ");
                string[] arguments = Console.ReadLine().Split(' ');

                Double result = double.NaN;
                result = calc.Exec(oper, arguments);

                Console.WriteLine($"{oper}({string.Join(", ", arguments)}) = {result}\n");
            }
        }

        static void PerfomBin(string op, Func<double, double , double> f)
        {
            double x, y;
            Console.Write("Введите чилсо x: ");
            double.TryParse(Console.ReadLine(), out x);
            Console.Write("Введите чилсо y: ");
            double.TryParse(Console.ReadLine(), out y);
            Console.WriteLine($"{op}({x}, {y}) = {f(x, y)}\n");
        }

        static void PerfomUn(string op, Func<double, double> f)
        {
            double x;
            Console.Write("Введите чилсо x: ");
            double.TryParse(Console.ReadLine(), out x);
            Console.WriteLine($"{op}({x}) = {f(x)}\n");
        }

    }
}
