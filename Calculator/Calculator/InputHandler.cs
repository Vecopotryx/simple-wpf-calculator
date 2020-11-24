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
                Calculate.CurrentEquation = Calculate.CurrentEquation.Split("\n = ")[1];
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
                    if(Calculate.CurrentEquation.Length > 0)
                    {
                        Calculate.CurrentEquation = Calculate.CurrentEquation.Remove(Calculate.CurrentEquation.Length - 1);
                    }
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