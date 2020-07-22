using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Multithreading_Equation
{
     public partial class EquationSettings : Window
    {
        readonly Regex validation = new Regex(@"\D");
        public Double A { get; set; }
        public Double B { get; set; }
        public Double N { get; set; }

        public EquationSettings()
        {
            InitializeComponent();
        }

        public void ButtonEnable(bool condition)
        {
            saveData.IsEnabled = condition;
        }

        public void SetEquationData(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(fieldA.Text))
                {
                    throw new Exception("Нижний предел интегрирования не заполнен");
                }
                else
                {
                    if (validation.IsMatch(fieldA.Text) == true)
                    {
                        throw new Exception("Все поля должны содержать целые числа");
                    }
                    else
                    {
                        A = double.Parse(fieldA.Text);
                    }
                }
                if (string.IsNullOrEmpty(fieldB.Text))
                {
                    throw new Exception("Верхний предел интегрирования не заполнен");
                }
                else
                {
                    if (validation.IsMatch(fieldB.Text) == true)
                    {
                        throw new Exception("Все поля должны содержать целые числа");
                    }
                    else
                    {
                        B = double.Parse(fieldB.Text);
                    }
                }
                if (string.IsNullOrEmpty(fieldN.Text))
                {
                    throw new Exception("Число разбиений не заполнено");
                }
                else
                {
                    if (validation.IsMatch(fieldN.Text) == true)
                    {
                        throw new Exception("Все поля должны содержать целые числа");
                    }
                    else
                    {
                        N = double.Parse(fieldN.Text);
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }        

    }

}
