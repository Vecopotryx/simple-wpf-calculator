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

        public static char LastOperator { get; set; }

        public double ParseCalculation(string expressionIn)
        {
            DataTable dt = new DataTable();
            expressionIn = expressionIn.Replace('x', '*');
            double result = Convert.ToDouble(dt.Compute(expressionIn, ""));
            /*
            double result = 0;
            if (currentInput.Contains('+'))
            {
                var currentInputSplitArray = currentInput.Split('+');
                var currentInputArray = currentInputSplitArray.Select(double.Parse).ToList();
                result = currentInputArray.Sum();
            }
            else if(currentInput.Contains('x'))
            {
                
            } else
            {
                result = double.Parse(CurrentEquation);
            }
            */
            return result;
        }
    }
}
