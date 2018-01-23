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
            Calc c = new Calc();
            if (args.Length == 3)
            {
                int a, b;
                int.TryParse(args[1], out a);
                int.TryParse(args[2], out b);
                string operat = args[0];
                if (operat == "sum")
                    Console.WriteLine($"{a} + {b} = {a + b}");
            }
            while (true)
            {
                Console.WriteLine("Выберите операцию: \n" +
                    "sum - Сложение\n" +
                    "sub - Вычитание\n" +
                    "mul - Умножение\n" +
                    "div - Деление\n" +
                    "square - Возведение в квадрат\n" +
                    "sqrt - Извлечение корня\n" +
                    "Для выхода из программы нажмите e");
                Console.Write("Ввод: ");

                string oper = Console.ReadLine();
                string x = Console.ReadLine();
                string y = Console.ReadLine();

                Double result = double.NaN;
                Calc calc = new Calc();

                result = calc.Exec(oper, new[] { x, y });

                Console.WriteLine($"{oper}({x}, {y}) = {result}");
                Console.ReadKey();
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
