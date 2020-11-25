using System;
using System.Data;

namespace Calculator
{
    class Calculate
    {
        public static string CurrentExpression { get; set; } = "";
        public double ParseCalculation(string expressionIn)
        {
            DataTable dt = new DataTable();
            expressionIn = expressionIn.Replace(',', '.'); // Replaces commas with dots, since DataTable.Compute doesn't work with commas
            expressionIn = expressionIn.Replace('x', '*'); // Replaces 'x' in the input string as DataTable.Compute requires '*' instead to work
            double result = Convert.ToDouble(dt.Compute(expressionIn, ""));
            return result;
        }
    }
}
