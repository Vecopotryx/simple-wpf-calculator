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
                        // Replacing commas with dots is necessary since the math parser doesn't like parsing commas and will instead crash.
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
                    // Stores the amount of opening and closing parentheses for comparison in order to make sure that they are balanced.

                    var curExp = Calculate.CurrentExpression; 
                    // Stores CurrentExpression in a shorter variable, not neccessery but improves readability in the if-statement down below.

                    if (openingAmount == closingAmount)
                    {
                        if (!(curExp.EndsWith('+') || curExp.EndsWith('-') || curExp.EndsWith('/') || curExp.EndsWith('x')))
                        {
                            // Checks whether or not to add a multiplication sign in front of the parentheses, as DataTable compute doesn't
                            // support expressions like "2(3+4)" and instead requires it to be formatted like "2*(3+4)".
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
                // Used to set the entire CurrentExpression to the answer when trying to add more numbers and operators after a calculation.
                // To the user it looks like it removes the first line (containing the previous calculation) and then lets them interact directly with the answer
                Calculate.CurrentExpression = Calculate.CurrentExpression.Split("\n = ")[1];
            }

        }
    }
}