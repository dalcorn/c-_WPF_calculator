using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Text.RegularExpressions;




namespace Final_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string function;
        private float num1;
        private float num2;
        private bool hasDecimal = false;

        private float result = 0;


        //textbox can only contain number values

        public string floatregex = @"^-?[0-9]\d*(.\d+)?$";

        // zero, but only if it isn't the first number
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
            {
                if (textBox.Text.Length >= 1)
                    textBox.Text = textBox.Text + 0;
            }
        }
        //one
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
                textBox.Text = textBox.Text + 1;
        }
        //two
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
                textBox.Text = textBox.Text + 2;
        }
        //three
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
                textBox.Text = textBox.Text + 3;
        }
        //four
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
                textBox.Text = textBox.Text + 4;
        }
        //five
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
                textBox.Text = textBox.Text + 5;
        }
        //six
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
                textBox.Text = textBox.Text + 6;
        }
        //seven
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
                textBox.Text = textBox.Text + 7;
        }
        //eight
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
                textBox.Text = textBox.Text + 8;
        }
        //nine
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (!textBox.IsReadOnly)
                textBox.Text = textBox.Text + 9;
        }
        //closes calculator
        private void Button_Click_off(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //clears textbox
        private void Button_Click_clr(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
            textBox.Clear();
            textBox.Focus();
            textBox.IsReadOnly = false;
        }
        //operators
        //addition : add culture info so math operation with decimals work on nonUS machines
        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(textBox.Text, floatregex))
            {
                num1 = float.Parse(textBox.Text, System.Globalization.CultureInfo.InvariantCulture);
                textBox.Clear();
                textBox.Focus();
                function = "add";

            }
            else if (!Regex.IsMatch(textBox.Text, floatregex))
            {
                textBox.Text = "error";
                textBox.IsReadOnly = true;

            }
        }
        //subtraction
        private void Button_Click_sub(object sender, RoutedEventArgs e)
        {
            //the number can be negative
            if (textBox.Text.Length < 1 && !textBox.IsReadOnly)
            {
                textBox.Text = textBox.Text + "-";
            }
            if (textBox.Text.Length > 1)
            {

                if (Regex.IsMatch(textBox.Text, floatregex))
                {
                    num1 = float.Parse(textBox.Text, System.Globalization.CultureInfo.InvariantCulture);
                    textBox.Clear();
                    textBox.Focus();
                    function = "sub";
                }
                else if (!Regex.IsMatch(textBox.Text, floatregex))
                {
                    textBox.Text = "error";
                    textBox.IsReadOnly = true;

                }
            }
        }
        //multiply
        private void Button_Click_mult(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(textBox.Text, floatregex))
            {
                num1 = float.Parse(textBox.Text, System.Globalization.CultureInfo.InvariantCulture);
                textBox.Clear();
                textBox.Focus();
                function = "mult";

            }
            else if (!Regex.IsMatch(textBox.Text, floatregex))
            {
                textBox.Text = "error";
                textBox.IsReadOnly = true;

            }
        }
        //divide
        private void Button_Click_div(object sender, RoutedEventArgs e)
        {

            if (Regex.IsMatch(textBox.Text, floatregex))
            {
                num1 = float.Parse(textBox.Text, System.Globalization.CultureInfo.InvariantCulture);
                textBox.Clear();
                textBox.Focus();
                function = "div";
            }
            else if (!Regex.IsMatch(textBox.Text, floatregex))
            {
                textBox.Text = "error";
                textBox.IsReadOnly = true;

            }
        }
        //decimal, but only one per number
        private void Button_Click_dec(object sender, RoutedEventArgs e)
        {
            if (!hasDecimal)
            {
                if (textBox.Text.Length != 0)
                {
                    textBox.Text = textBox.Text + ".";

                }
                else
                {
                    textBox.Text = textBox.Text + "0.";
                }
            }
        }
        //equals
        private void Button_Click_eq(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(textBox.Text, floatregex))
            {
                num2 = float.Parse(textBox.Text, System.Globalization.CultureInfo.InvariantCulture);
                calculate();
            }
            else if (!Regex.IsMatch(textBox.Text, floatregex))
            {
                textBox.Text = "error";
                textBox.IsReadOnly = true;

            }
        }

        //do the calculations

        private void calculate()
        {
            switch (function)
            {
                case "add":
                    result = num1 + num2;
                    textBox.Text = result.ToString();
                    num1 = result;
                    break;
                case "sub":
                    result = num1 - num2;
                    textBox.Text = result.ToString();
                    num1 = result;
                    break;
                case "mult":
                    result = num1 * num2;
                    textBox.Text = result.ToString();
                    num1 = result;
                    break;
                case "div":
                    result = num1 / num2;
                    textBox.Text = result.ToString();
                    num1 = result;
                    break;
            }
        }
        //do not allow alpha characters from keyboard
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            char keyPressed = (char)e.Key;
            if (!Char.IsLetter(keyPressed))
            {
                e.Handled = true;
                return;
            }
        }
    }
}

