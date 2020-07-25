using EducationDB.entity;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EducationDB
{
    public partial class CreateWindow : Window
    {
        OpenFileDialog newPhoto = null;

        public CreateWindow()
        {
            InitializeComponent();
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (AppDbContext studentsDB = new AppDbContext())
                {
                    Student student = new Student
                    {
                        Name = tbName.Text,
                        Surname = tbSurname.Text,
                        Gender = CheckGender()
                    };
                    Regex number = new Regex(@"\D");
                    if (number.IsMatch(tbAge.Text) == true)
                    {
                        throw new Exception("Возраст должен быть числом");
                    }
                    else
                    {
                        student.Age = int.Parse(tbAge.Text);
                    }
                    if (number.IsMatch(tbGroup.Text) == true)
                    {
                        throw new Exception("Номер группы должен быть числом");
                    }
                    else
                    {
                        student.GroupNumber = int.Parse(tbGroup.Text);
                    }
                    if (newPhoto != null)
                    {
                        if (newPhoto.FileName != "")
                        {
                            student.Photo = File.ReadAllBytes(newPhoto.FileName);
                        }
                        else { student.Photo = null; }
                    }
                    studentsDB.Students.Add(student);
                    studentsDB.SaveChanges();
                    newPhoto = null;
                }
                Close();
            }
            catch (Exception E)
            {
                System.Windows.MessageBox.Show(E.Message);
            }
        }

        private string CheckGender()
        {
            return (cbMan.IsChecked == true) ? "М" : ((cbWoman.IsChecked == true) ? "Ж" : "?");
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbSurname.Text) || string.IsNullOrEmpty(tbAge.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            newPhoto = new OpenFileDialog
            {
                Filter = "Изображение (*.jpg)|*.jpg|Все файлы (*.*)|*.*"
            };
            if (newPhoto.ShowDialog() == true)
            {
                Uri fileUri = new Uri(newPhoto.FileName);
                studentPhoto.Source = new BitmapImage(fileUri);
            }
        }

    }

}
