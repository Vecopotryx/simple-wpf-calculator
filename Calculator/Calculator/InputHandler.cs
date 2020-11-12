using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class InputHandler
    {
        private View view = new View();
        private Calculate calculate = new Calculate();
        public void CalculatorInputHandler(string operatorIn)
        {
            // MainWindow.TextDisplay.Text += operatorIn;
            if(operatorIn == "=")
            {
                MainWindow.AppWindow.TextDisplay.Text = calculate.ParseCalculation(MainWindow.AppWindow.TextDisplay.Text).ToString();
            } else
            {
                view.AddToTextBox(operatorIn);
            }
        }
    }
}
