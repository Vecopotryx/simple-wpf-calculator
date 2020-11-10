using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class InputHandler
    {
        private View view = new View();

        public void CalculatorInputHandler(string operatorIn)
        {
            // MainWindow.TextDisplay.Text += operatorIn;
            view.AddToTextBox(operatorIn);

        }
    }
}
