using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class InputHandler
    {
        private Calculate calculate = new Calculate();
        public void CalculatorInputHandler(string operatorIn)
        {
            // 
            if(operatorIn == "=")
            {
                Calculate.CurrentEquation = calculate.ParseCalculation(Calculate.CurrentEquation).ToString();
            } else
            {
                Calculate.CurrentEquation += operatorIn;
            }

        }
    }
}
