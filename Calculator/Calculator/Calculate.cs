using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class Calculate
    {
        public static string CurrentEquation { get; set; }

        public static char LastOperation { get; set; }

        public int currentCalculation;

        public double ParseCalculation(string currentInput)
        {
            double result = 0;
            if (currentInput.Contains('+'))
            {
                var currentInputSplitArray = currentInput.Split('+');
                var currentInputArray = currentInputSplitArray.Select(double.Parse).ToList();
                result = currentInputArray.Sum();
            }
            else
            {

            }

            return result;
        }
    }
}
