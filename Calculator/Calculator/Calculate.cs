using System;
using System.Data;

namespace Calculator
{
    class Calculate
    {
        public static string CurrentEquation { get; set; }
        public static double LastAnswer { get; set; }
        public double ParseCalculation(string expressionIn)
        {
            DataTable dt = new DataTable();
            expressionIn = expressionIn.Replace('x', '*');
            double result = Convert.ToDouble(dt.Compute(expressionIn, ""));
            LastAnswer = result;
            return result;
        }
    }
}
