using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InputHandler input = new InputHandler();        

        public MainWindow()
        {
            InitializeComponent();
            TextDisplay.Focus();
        }

        private void HandleInput(object sender, RoutedEventArgs e)
        {
            Button buttonIn = e.Source as Button;

            char operatorIn = buttonIn.Content.ToString().ToCharArray()[0]; // Gets the first character from the button Content, example: "( )" gives '('.

            Calculate.CurrentExpression = TextDisplay.Text; // Updates CurrentExpression with the contents of TextDisplay before acting on input.

            input.CalculatorInputHandler(operatorIn); // Calls the InputHandler which acts according to the charcter that was stored previously from the button.

            TextDisplay.Text = Calculate.CurrentExpression; // Sets TextDisplay to CurrentExpression, which will have been updated after calling the InputHandler.

            TextDisplay.Focus(); // Returns focus to the TextDisplay, in order to allow the user to start typing with their keyboard if they so desire.

            TextDisplay.CaretIndex = Calculate.CurrentExpression.Length; // Moves the caret, so that any keyboard input will be put at the end of the expression.
        }

        private void TextDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            Calculate.CurrentExpression = TextDisplay.Text; //  Updates CurrentExpression with the contents of TextDisplay before acting on input. 

            input.CheckCurrentEquation();

            if (e.Key == Key.Enter)
            {
                input.CalculatorInputHandler('='); // Simulates input of '=' when user presses enter in the TextDisplay. This in turn causes the InputHandler to call the Calculate class.
            }

            TextDisplay.Text = Calculate.CurrentExpression; // Sets TextDisplay to CurrentExpression, just in case anything has been updated.

            TextDisplay.CaretIndex = Calculate.CurrentExpression.Length;
        }
    }
}
