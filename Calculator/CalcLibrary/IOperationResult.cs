using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    /// <summary>
    /// Результат операции
    /// </summary>
    public interface IOperationResult
    {
        double Result { get; set; }

        string Error { get; set; }
    }
}
