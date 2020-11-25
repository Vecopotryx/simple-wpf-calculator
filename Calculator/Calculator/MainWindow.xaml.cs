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

            char operatorIn = buttonIn.Content.ToString().ToCharArray()[0];

            Calculate.CurrentExpression = TextDisplay.Text;

            input.CalculatorInputHandler(operatorIn);

            TextDisplay.Text = Calculate.CurrentExpression;

            TextDisplay.Focus();

            TextDisplay.CaretIndex = Calculate.CurrentExpression.Length;
        }

        private void TextDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            Calculate.CurrentExpression = TextDisplay.Text;

            input.CheckCurrentEquation();

            if (e.Key == Key.Enter)
            {
                input.CalculatorInputHandler('=');
            }

            TextDisplay.Text = Calculate.CurrentExpression;

            TextDisplay.CaretIndex = Calculate.CurrentExpression.Length;

        }
    }
}
