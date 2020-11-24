using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class InputHandler
    {
        private Calculate calculate = new Calculate();
        public void CalculatorInputHandler(char operatorIn)
        {
            // 
            // Calculate.CurrentEquation.EndsWith(operatorIn)
            if (operatorIn == '=')
            {
                bool endsWithOperator = false;
                char[] operatorList = { '/', 'x', '+', '-' };
                foreach (char currentOperator in operatorList)
                {
                    if (Calculate.CurrentEquation.EndsWith(currentOperator))
                    {
                        endsWithOperator = true;
                        break;
                    }
                }
                if (endsWithOperator)
                {
                    Calculate.CurrentEquation = "Error";
                } else
                {
                    Calculate.CurrentEquation = calculate.ParseCalculation(Calculate.CurrentEquation).ToString();

                }
            } else if (operatorIn == 'C')
            {
                Calculate.CurrentEquation = "";
            } else
            {
                Calculate.CurrentEquation += operatorIn;
            }
        }
    }
}

/*                if (operatorIn == '/' || operatorIn == 'x' || operatorIn == '+' || operatorIn == '-')
                {

                }
*/