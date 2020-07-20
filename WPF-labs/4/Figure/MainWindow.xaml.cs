using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;

namespace Figure
{
    public partial class MainWindow : Window
    {
        ColorDialog dialogBrush, dialogFon;
        readonly ObservableCollection<Figure> figures = new ObservableCollection<Figure>();
        OpenFileDialog ofd;
        SaveFileDialog sfd;
        Figure figure;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SpaceMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(canvas);
            Figure newFigure = new Figure(point.X, point.Y, BuFon.Background, BuLine.Background, slWight.Value);
            Grid.Children.Add(newFigure.path);
            figures.Add(newFigure);
        }

        private void SpaceMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point point = e.GetPosition(canvas);
            Status.Content = string.Format("X={0:f0} Y={1:f0} ||    ||", point.X, point.Y);
        }


        private void ChangeFon(object sender, RoutedEventArgs e)
        {
            dialogFon = new ColorDialog
            {
                FullOpen = true
            };
            dialogFon.ShowDialog();
            System.Drawing.Color color = dialogFon.Color;
            Color newColor = Color.FromRgb(color.R, color.G, color.B);
            BuFon.Background = new SolidColorBrush(newColor);
        }

        private void ChangeBrush(object sender, RoutedEventArgs e)
        {
            dialogBrush = new ColorDialog
            {
                FullOpen = true
            };
            dialogBrush.ShowDialog();
            System.Drawing.Color color = dialogBrush.Color;
            Color newColor = Color.FromRgb(color.R, color.G, color.B);
            BuLine.Background = new SolidColorBrush(newColor);
        }
       
        private void OpenFile(object sender, ExecutedRoutedEventArgs e)
        {
            ofd = new OpenFileDialog
            {
                InitialDirectory = "C:\\temp",
                Filter = "Текстовый файл (*.txt)|*.txt|Все файлы (*.*)|*.*",
                CheckFileExists = true,
                Multiselect = true
            };
            ofd.ShowDialog();
            if (string.IsNullOrEmpty(ofd.FileName) == false)
            {
                figures.Clear();
                string[] FileText = File.ReadAllLines(ofd.FileName);
                stbFile.Content = string.Format("Файл: {0}", ofd.FileName);
                Grid.Children.Clear();
                Grid.Children.Add(canvas);
                int s = 0;
                figure = new Figure();
                for (int i = 0; i < FileText.GetLength(0); i++)
                {
                    s++;
                    switch (s)
                    {
                        case 1: 
                            figure.X = double.Parse(FileText[i]); 
                            break;
                        case 2: 
                            figure.Y = double.Parse(FileText[i]); 
                            break;
                        case 3: 
                            figure.fon = new SolidColorBrush((Color)ColorConverter.ConvertFromString(FileText[i])); 
                            break;
                        case 4: 
                            figure.line = new SolidColorBrush((Color)ColorConverter.ConvertFromString(FileText[i])); 
                            break;
                        case 5:
                            figure.width = double.Parse(FileText[i]);
                            figure.DrawFigure();
                            Grid.Children.Add(figure.path);
                            figures.Add(figure);
                            s = 0; 
                            figure = new Figure(); 
                            break;
                    }
                }
            }
        }
                
        private void SaveFile(object sender, ExecutedRoutedEventArgs e)
        {
            sfd = new SaveFileDialog
            {
                InitialDirectory = "C:\\temp",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                OverwritePrompt = false,                
            };
            sfd.ShowDialog();
            if (string.IsNullOrEmpty(sfd.FileName) == false)
            {
                File.WriteAllLines(sfd.FileName, GetDescription());
                stbFile.Content = string.Format("Файл: {0}", sfd.FileName);
            }
        }

        private List<string> GetDescription()
        {
            var FileText = new List<string>();
            foreach (Figure a in figures)
            {
                FileText.Add(a.X.ToString());
                FileText.Add(a.Y.ToString());
                FileText.Add(a.fon.ToString());
                FileText.Add(a.line.ToString());
                FileText.Add(a.width.ToString());
            }
            return FileText;
        }

    }
}
