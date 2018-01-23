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
            if (args.Length == 3)
            {
                int a, b;
                int.TryParse(args[1], out a);
                int.TryParse(args[2], out b);
                var oper = args[0];
                if (oper == "sum")
                    Console.WriteLine($"{a} + {b} = {a + b}");
            }
            Calc calc = new Calc();
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
                string selOper = Console.ReadLine();
                switch(selOper)
                {
                    case "sum":
                        PerfomBin("sum", calc.Sum);
                        break;
                    case "sub":
                        PerfomBin("sub", calc.Sub);
                        break;
                    case "mul":
                        PerfomBin("mul", calc.Mul);
                        break;
                    case "div":
                        PerfomBin("div", calc.Div);
                        break;
                    case "square":
                        PerfomUn("square", calc.Square);
                        break;
                    case "sqrt":
                        PerfomUn("sqrt", calc.Sqrt);
                        break;
                    case "e":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверная операция, повторите ввод\n");
                        break;
                }
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
