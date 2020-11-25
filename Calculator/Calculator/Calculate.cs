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
            expressionIn = expressionIn.Replace('x', '*');
            double result = Convert.ToDouble(dt.Compute(expressionIn, ""));
            return result;
        }
    }
}
