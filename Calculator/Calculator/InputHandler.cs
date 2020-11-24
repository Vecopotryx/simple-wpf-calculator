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

            if(Calculate.CurrentEquation == "Error!")
            {
                Calculate.CurrentEquation = "";
            }

            if (operatorIn == '=')
            {
                try
                {
                    Calculate.CurrentEquation = calculate.ParseCalculation(Calculate.CurrentEquation).ToString();

                } catch
                {
                    Calculate.CurrentEquation = "Error!";
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