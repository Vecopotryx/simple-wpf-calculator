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
            CheckCurrentEquation();

            switch (operatorIn)
            {
                case '=':
                    try
                    {
                        Calculate.CurrentExpression += "\n = " + calculate.ParseCalculation(Calculate.CurrentExpression).ToString().Replace(',', '.');
                        // This is necessary since the math parser doesn't like parsing commas and will instead crash.
                    }
                    catch
                    {
                        Calculate.CurrentExpression = "Error!";
                    }
                    break;
                case 'C':
                    Calculate.CurrentExpression = "";
                    break;
                case '←':
                    if(Calculate.CurrentExpression.Length > 0)
                    {
                        Calculate.CurrentExpression = Calculate.CurrentExpression.Remove(Calculate.CurrentExpression.Length - 1);
                    }
                    break;
                case '(':
                    int openingAmount = Calculate.CurrentExpression.Count(f => f == '(');
                    int closingAmount = Calculate.CurrentExpression.Count(f => f == ')');

                    var curExp = Calculate.CurrentExpression;

                    if (openingAmount == closingAmount)
                    {
                        if (!(curExp.EndsWith('+') || curExp.EndsWith('-') || curExp.EndsWith('/') || curExp.EndsWith('x')))
                        {
                            Calculate.CurrentExpression += 'x';
                        }
                        Calculate.CurrentExpression += '(';
                    } else
                    {
                        Calculate.CurrentExpression += ')';
                    }
                    break;
                default:
                    Calculate.CurrentExpression += operatorIn;
                    break;
            }
        }

        public void CheckCurrentEquation()
        {
            if (Calculate.CurrentExpression == "Error!")
            {
                Calculate.CurrentExpression = "";
            }

            if (Calculate.CurrentExpression.Contains("\n"))
            {
                Calculate.CurrentExpression = Calculate.CurrentExpression.Split("\n = ")[1];
            }

        }
    }
}