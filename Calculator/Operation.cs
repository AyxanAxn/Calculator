using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum OperatorType
    {
        Add,
        Sub,
        Mul,
        Div
    }

    class Operation
    {
        //1
        public string FirstValue { get; set; }
        public string SecondValue { get; set; }
        public OperatorType Operator { get; set; }

        public Operation()
        {
            FirstValue = string.Empty;
            SecondValue = string.Empty;
        }
        public string Calculate()
        {
            switch (Operator)
            {
                case OperatorType.Add:
                    return (Convert.ToDouble(FirstValue) + Convert.ToDouble(SecondValue)).ToString();
                case OperatorType.Sub:
                    return (Convert.ToDouble(FirstValue) - Convert.ToDouble(SecondValue)).ToString();
                case OperatorType.Mul:
                    return (Convert.ToDouble(FirstValue) * Convert.ToDouble(SecondValue)).ToString();
                case OperatorType.Div:
                    return (Convert.ToDouble(FirstValue) / Convert.ToDouble(SecondValue)).ToString();
                default:
                    throw new InvalidOperationException();

            }
        }
        public OperatorType GetOperatorType(string oprt)
        {

            switch (oprt)
            {
                case "+":
                    return OperatorType.Add;
                case "-":
                    return OperatorType.Sub;
                case "x":
                    return OperatorType.Mul;
                case "/":
                    return OperatorType.Div;
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }


        }

    }
}
