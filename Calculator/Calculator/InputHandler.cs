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
            
            if(Calculate.CurrentEquation == "Error!")
            {
                Calculate.CurrentEquation = "";
            }

            if (Calculate.CurrentEquation.Contains("\n"))
            {
                Calculate.CurrentEquation = Calculate.LastAnswer.ToString();
            }

            switch (operatorIn)
            {
                case '=':
                    try
                    {
                        Calculate.CurrentEquation += "\n = " + calculate.ParseCalculation(Calculate.CurrentEquation).ToString();
                    }
                    catch
                    {
                        Calculate.CurrentEquation = "Error!";
                    }
                    break;
                case 'C':
                    Calculate.CurrentEquation = "";
                    break;
                case 'a':
                    break;
                default:
                    Calculate.CurrentEquation += operatorIn;
                    break;
            }

        }
    }
}