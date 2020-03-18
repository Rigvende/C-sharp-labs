using System;
using System.Windows;
using System.Windows.Controls;

namespace XamlApp
{
    public partial class Calculator : Window
    {
        private string firstNumber = "";                                // первое число
        private string operation = "";                                  // знак
        private string secondNumber = "";                               // второе число

        public Calculator()
        {
            InitializeComponent();
            foreach (UIElement element in LayoutRoot.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += Button_Click;            // обработчик события при нажатии каждой кнопки
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = (string)((Button)e.OriginalSource).Content;  // содержимое кнопки
            textBlock.Text += input;
            bool result = Double.TryParse(input, out _);
            if (result)
            {
                if (operation == "")                                    // если не выбрали (не нажали) операцию
                {
                    firstNumber += input;                               // создаём первое число
                }
                else
                {
                    secondNumber += input;                              // если нажали - создаём второе число
                }
            }
            else
            {
                if (input == "=")                                       // вывод результата
                {
                    Calculate();
                    textBlock.Text += secondNumber;
                    operation = "";
                    firstNumber = secondNumber;
                    secondNumber = "";
                }
                else if (input == "," && secondNumber == "")            // дробная часть
                {
                    firstNumber += input;
                }
                else if (input == "," && secondNumber != "")
                {
                    secondNumber += input;
                }
                else if (input == "CLEAR")                              // очистка поля
                {
                    firstNumber = "";
                    secondNumber = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else if (input == "-" && firstNumber == "")             // первое число - отрицательное
                {
                    firstNumber = input;
                }
                else if (input == "-" && operation != "" && operation != "-")    // второе число - отрицательное
                {
                    secondNumber = input;
                }
                else                                                    
                {
                    if (secondNumber != "")                             // возможность продолжить выполнение до нажатия =
                    {
                        Calculate();
                        operation = "";
                        firstNumber = secondNumber;
                        secondNumber = "";
                    }
                    operation = input;
                }
            }
        }
        
        private void Calculate()
        {
            double num1;                                                // пробуем преобразовать строковое значение в double
            double num2;
            if (firstNumber != "" && firstNumber != "-" 
                                  && firstNumber != "," 
                                  && firstNumber != "not defined")
            {
                num1 = Math.Round(Double.Parse(firstNumber), 4);                    
            }
            else
            {
                num1 = 0;
            }
            if (secondNumber != "" && secondNumber != "-" && secondNumber != ",")
            {
                num2 = Math.Round(Double.Parse(secondNumber), 4);
            }
            else
            {
                num2 = num1;
            }
            switch (operation)                                          // совершение операции в зависимости от нажатой кнопки
            {
                case "+":
                    secondNumber = Math.Round(num1 + num2, 4).ToString();
                    break;
                case "-":
                    secondNumber = Math.Round(num1 - num2, 4).ToString();
                    break;
                case "*":
                    secondNumber = Math.Round(num1 * num2, 4).ToString();
                    break;
                case "/": 
                    secondNumber = Math.Round(num1 / num2, 4).ToString();            // проверки деления на 0 нет, потому что будет infinity
                    break;
                case "SIN":
                    if ((bool)Degree.IsChecked)
                    {
                        
                        secondNumber = Math.Round(Math.Sin(num1 * Math.PI / 180), 4).ToString();
                    }
                    if ((bool)Radian.IsChecked)
                    {
                        secondNumber = Math.Round(Math.Sin(num1), 4).ToString();
                    }
                    break;
                case "COS":
                    if ((bool)Degree.IsChecked)
                    {
                        secondNumber = Math.Round(Math.Cos(num1 * Math.PI / 180), 4).ToString();
                    }
                    if ((bool)Radian.IsChecked)
                    {
                        secondNumber = Math.Round(Math.Cos(num1), 4).ToString();
                    }
                    break;
                case "TAN":
                    if ((bool)Degree.IsChecked)
                    {
                        if (num1 == 90 || num1 == 270)
                        {
                            secondNumber = "not defined";
                        }
                        else
                        {
                            secondNumber = Math.Round(Math.Tan(num1 * Math.PI / 180), 4).ToString();
                        }
                    }
                    if ((bool)Radian.IsChecked)
                    {
                        secondNumber = Math.Round(Math.Tan(num1), 4).ToString();
                    }
                    break;
                case "SQRT":
                    secondNumber = Math.Round(Math.Sqrt(num1), 4).ToString();        // проверки на отрицательное число нет, потому что будет NaN
                    break;
                default:
                    secondNumber = firstNumber;
                    break;
            }
        }
    }
}