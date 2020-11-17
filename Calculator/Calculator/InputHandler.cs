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
            
            if (operatorIn == '=')
            {
                Calculate.LastOperator = '\0'; // Sets LastOperator to unicode null
                Calculate.CurrentEquation = calculate.ParseCalculation(Calculate.CurrentEquation).ToString();
            } else if(operatorIn == 'C')
            {
                Calculate.CurrentEquation = "";
            } else
            {
                if (operatorIn == '/' || operatorIn == 'x' || operatorIn == '+' || operatorIn == '-')
                {

                    if ((Calculate.LastOperator == '\0' || operatorIn == Calculate.LastOperator) && !Calculate.CurrentEquation.EndsWith(operatorIn))
                    {
                        Calculate.CurrentEquation += operatorIn;
                        Calculate.LastOperator = operatorIn;
                    }
                } else
                {
                    Calculate.CurrentEquation += operatorIn;
                }
            }
        }
    }
}
