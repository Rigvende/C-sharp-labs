using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Rows
{
    public partial class MainWindow : Window
    {
        readonly Values valueSet;
        readonly ObservableCollection<string> results;

        public MainWindow()
        {
            InitializeComponent();
            valueSet = new Values();
            grid.DataContext = valueSet;

            results = new ObservableCollection<string>();
            lResult.DataContext = results;
        }

        private void Btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            valueSet.GetResults(results);
        }

        private void CheckStopBox()
        {
            BindingExpression bindingStop = txtBox_Xstop.GetBindingExpression(TextBox.TextProperty);
            bindingStop.UpdateSource();
        }

        private void CheckBothBoxes()
        {
            BindingExpression bindingStart = txtBox_XStart.GetBindingExpression(TextBox.TextProperty);
            bindingStart.UpdateSource();
            CheckStopBox();
        }

        private void TxtBox_Xstop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                CheckStopBox();
            }
        }

        private void TxtBox_Xstop_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckStopBox();
        }

        private void TxtBox_XStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                CheckBothBoxes();
            }
        }

        private void TxtBox_XStart_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckBothBoxes();
        }
    }
}