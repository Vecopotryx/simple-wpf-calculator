using System;
using System.Collections.Generic;
using System.Linq;
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
                case '←':
                    Calculate.CurrentEquation = Calculate.CurrentEquation.Remove(Calculate.CurrentEquation.Length - 1);
                    break;
                case '(':
                    int openingAmount = Calculate.CurrentEquation.Count(f => f == '(');
                    int closingAmount = Calculate.CurrentEquation.Count(f => f == ')');

                    if (openingAmount == closingAmount)
                    {
                        Calculate.CurrentEquation += '(';
                    } else
                    {
                        Calculate.CurrentEquation += ')';
                    }

                    break;
                default:
                    Calculate.CurrentEquation += operatorIn;
                    break;
            }

        }
    }
}