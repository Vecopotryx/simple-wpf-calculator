using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class View
    {
        public void AddToTextBox(string textIn)
        {
            MainWindow.AppWindow.TextDisplay.Text += textIn; 
        }
        

    }
}
