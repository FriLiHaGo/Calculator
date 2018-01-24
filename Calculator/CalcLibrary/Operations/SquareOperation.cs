using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations
{
    public class SquareOperation: NumberOperation
    {
        public override string Name => "square";

        public override IOperationResult Exec(IEnumerable<double> args)
        {
            var result = (args.Count() >= 1)
                ? args.ElementAt(0) * args.ElementAt(0)
                : double.NaN;

            return new OperResult(result, null);
        }
    }
}
