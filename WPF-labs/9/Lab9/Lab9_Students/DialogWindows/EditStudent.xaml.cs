using Lab9.BusinessLayer.Interfaces;
using Lab9.BusinessLayer.Models;
using Lab9.BusinessLayer.Services;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Lab9_Students.DialogWindows
{
    public partial class EditStudent : Window
    {
        bool hasStudentId = false;
        int studentId;
        int groupId;
        StudentDto studentDto;

        public EditStudent()
        {
            InitializeComponent();
        }

        public EditStudent(StudentDto studentDto) : this()
        {
            this.studentDto = studentDto;
            gridStudent.DataContext = studentDto;
        }

        public EditStudent(StudentDto studentDto, GroupDto groupDto) : this()
        {
            this.studentDto = studentDto;
            gridStudent.DataContext = studentDto;
            Name.Text = studentDto.Name;
            datePickerBirth.SelectedDate = studentDto.DateOfBirth;
            if (studentDto.IndividualPrice == groupDto.Price)
            {
                checkBoxDiscount.IsChecked = false;
                studentDto.HasDiscount = false;
            }
            else
            {
                checkBoxDiscount.IsChecked = true;
                studentDto.HasDiscount = true;
            }
            Photo.Text = studentDto.Photo;
            hasStudentId = true;
            studentId = studentDto.StudentId;
            groupId = groupDto.GroupId;
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Photo.Text == "")
            {
                MessageBox.Show("Не заполнены обязательные поля (*)", "", 
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "images") + "\\" + Photo.Text))
            {
                MessageBox.Show("Укажите путь к файлу фото, сделав двойной клик на поле ввода", "", 
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!hasStudentId)
            {
                studentDto.Name = Name.Text;
                if (datePickerBirth.SelectedDate != null)
                {
                    studentDto.DateOfBirth = (DateTime)datePickerBirth.SelectedDate;
                }
                if (checkBoxDiscount.IsChecked == true)
                {
                    studentDto.HasDiscount = true;
                }
                DialogResult = true;
                Close();
            }
            else if (hasStudentId)
            {
                IStudentService studentService = new StudentService("StudentsLab9_connection");
                StudentDto editedStudent = new StudentDto
                {
                    Name = Name.Text,
                    DateOfBirth = (DateTime)datePickerBirth.SelectedDate
                };

                if (checkBoxDiscount.IsChecked == true)
                {
                    editedStudent.HasDiscount = true;
                    if (studentDto.HasDiscount == true)
                    {
                        editedStudent.IndividualPrice = studentDto.IndividualPrice;
                    }
                    else if (studentDto.HasDiscount == false)
                    {
                        editedStudent.IndividualPrice = studentDto.IndividualPrice * (decimal)(100.0 / 80.0);
                    }
                }
                else if (checkBoxDiscount.IsChecked == false)
                {
                    editedStudent.HasDiscount = false;
                    if (studentDto.HasDiscount == true)
                    {
                        editedStudent.IndividualPrice = studentDto.IndividualPrice * (decimal)(100.0 / 80.0);
                    }
                    else if (studentDto.HasDiscount == false)
                    {
                        editedStudent.IndividualPrice = studentDto.IndividualPrice;
                    }
                }
                editedStudent.Photo = Photo.Text;
                editedStudent.StudentId = studentId;
                editedStudent.GroupId = groupId;
                studentService.UpdateStudent(editedStudent);
                Close();
            }
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Photo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string path = Path.Combine((new DirectoryInfo(Directory.GetCurrentDirectory())).FullName, "images");
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "photo files(*.jpg)|*.jpg"
            };
            ofd.ShowDialog();
            var name = "_" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
            path += "\\" + name + ".jpg";
            if (!ofd.FileName.Equals(""))
            { 
                File.Copy(ofd.FileName, path);
                Photo.Text = Convert.ToString(name) + ".jpg";               
            } 
            else
            {
                MessageBox.Show("Вы не выбрали файл фото", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }

}