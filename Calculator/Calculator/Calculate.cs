using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Calculator
{
    class Calculate
    {
        public static string CurrentEquation { get; set; }

        public double ParseCalculation(string expressionIn)
        {
            DataTable dt = new DataTable();
            expressionIn = expressionIn.Replace('x', '*');
            double result = Convert.ToDouble(dt.Compute(expressionIn, ""));
            return result;
        }
    }
}
