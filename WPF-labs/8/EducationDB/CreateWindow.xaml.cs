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
                    int ageParsed = int.Parse(tbAge.Text);
                    if (number.IsMatch(tbAge.Text) == true || ageParsed > 100 || ageParsed < 16)
                    {
                        throw new Exception("Возраст должен быть числом от 16 до 99");
                    }
                    else
                    {
                        student.Age = ageParsed;
                    }
                    int groupParsed = int.Parse(tbGroup.Text);
                    if (number.IsMatch(tbGroup.Text) == true || groupParsed < 1 || groupParsed > int.MaxValue - 1)
                    {
                        throw new Exception("Номер группы должен быть положительным числом");
                    }
                    else
                    {
                        student.GroupNumber = groupParsed;
                    }
                    if (newPhoto != null)
                    {
                        if (newPhoto.FileName != "")
                        {
                            student.Photo = File.ReadAllBytes(newPhoto.FileName);
                        }
                        
                    } else if (studentPhoto != null)
                    {                        
                        student.Photo = GetPhoto((BitmapSource)studentPhoto.Source);
                    }
                    else 
                    { 
                        student.Photo = null; 
                    }
                    if (!idSt.Text.Equals(""))
                    {
                        studentsDB.Students.Remove(studentsDB.Students.Find(int.Parse(idSt.Text)));
                    }
                    studentsDB.Students.Add(student);
                    studentsDB.SaveChanges();
                    newPhoto = null;
                }
                Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private byte[] GetPhoto(BitmapSource source)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(source));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }

}
