using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations
{
    public class MulOperation : NumberOperation
    {
        public override string Name => "mul";

        public override IOperationResult Exec(IEnumerable<double> args)
        {
            return new OperResult(args.Aggregate((a, b) => a * b), null);
        }
    }
}
