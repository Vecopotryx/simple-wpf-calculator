using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class InputHandler
    {
        private Calculate calculate = new Calculate();

        private string operators = "+-/x";
        public void CalculatorInputHandler(char operatorIn)
        {
            CheckCurrentEquation();

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
                        foreach(char currentOperator in operators.ToCharArray())
                        {
                            if (!Calculate.CurrentEquation.EndsWith(currentOperator))
                            {
                                Calculate.CurrentEquation += '*';
                                break;
                            }
                        }
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

        public void CheckCurrentEquation()
        {
            if (Calculate.CurrentEquation == "Error!")
            {
                Calculate.CurrentEquation = "";
            }

            if (Calculate.CurrentEquation.Contains("\n"))
            {
                Calculate.CurrentEquation = Calculate.CurrentEquation.Split("\n = ")[1];
            }

        }
    }
}