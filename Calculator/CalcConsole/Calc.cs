using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsole
{
    public class Calc
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }

        public int Sub(int x, int y)
        {
            return x - y;
        }

        public double Sum(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Div(double x, double y)
        {
            if(y != 0)
            {
                return x / y;
            }
            return double.NaN;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Square(double x)
        {
            return x * x;
        }

        public double Sqrt(double x)
        {
            if(x >= 0)
            {
                return Math.Sqrt(x);
            }
            return double.NaN;
        }
    }
}
