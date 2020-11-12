using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class Calculate
    {

        int result;

        public double ParseCalculation(string currentInput)
        {
            if (currentInput.Contains('+'))
            {
                var currentInputSplitArray = currentInput.Split('+');
                var currentInputArray = currentInputSplitArray.Select(double.Parse).ToList();

                /*                for(int i = 0; i < currentInputSplitArray.Length; i++)
                                {
                                    result += int.Parse(currentInputSplitArray[i]);
                                }

                                return result;*/
                return currentInputArray.Sum();
            } else
            {
                return 0;
            }
        }
    }
}
