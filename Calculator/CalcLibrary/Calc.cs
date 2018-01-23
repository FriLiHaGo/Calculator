using CalcLibrary.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    public class Calc
    {
        public Calc()
        {
            Operations = new List<IOperation>();

            var curAssemly= Assembly.GetExecutingAssembly();
            var types = curAssemly.GetTypes();
            foreach (var type in types)
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;
                var interfaces = type.GetInterfaces();
                if (interfaces.Contains(typeof(IOperation)))
                {
                    var obj = Activator.CreateInstance(type) as IOperation;
                    if(obj != null)
                    {
                        Operations.Add(obj);
                    }
                }
            }
        }

        private IList<IOperation> Operations;

        public double Exec(string operationName, string[] args)
        {
            IOperation oper;
            // найти операцию в списке операций

            //select top 1 *
            //from Operations
            //where Name = operationName
            oper = Operations.FirstOrDefault(it => it.Name == operationName);
            // если не удалось найти - возвращаем NaN
            if (oper == null)
            {
                return double.NaN;
            }
            // иначе 
            // вычисляем результат операции
            var result = oper.Exec(args);
            // если в результате ошибка заполена 
            if (!string.IsNullOrWhiteSpace(result.Error))
            {
                //выводим ее на экран
            }
            else
            {
                // иначе выводим результат
                return result.Result;
            }
            //дефолтное значение
            return double.NaN;
        }


        #region Int
        [Obsolete("Не использовать")]
        public int Sum(int x, int y)
        {
            return (int)Sum((double)x, (double)y);
        }

        [Obsolete("Не использовать")]
        public int Sub(int x, int y)
        {
            return (int)Sub((double)x, (double)y);
        }
        #endregion

        #region Double
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
            if (y != 0)
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
            if (x >= 0)
            {
                return Math.Sqrt(x);
            }
            return double.NaN;
        }
        #endregion
    }
}
