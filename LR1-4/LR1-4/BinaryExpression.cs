using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1_4
{
    class BinaryExpression
    {
        public string Operand1 { get; set; } = "";
        public string Operand2 { get; set; } = "";
        public Func<double, double, double>? Operator = null;
        public string OperatorString { get; set; } = "";
        public double Evaluate()
        {
            if (Operand1 == "" || Operand2 == "" || OperatorString == "") throw new Exception();
            double operand1 = Convert.ToDouble(Operand1);
            double operand2 = Convert.ToDouble(Operand2);
            if (Operator is null) throw new Exception();
            return Operator.Invoke(operand1, operand2);
        }
    }
}
