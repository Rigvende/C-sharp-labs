using EducationDB.entity;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EducationDB
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            using (AppDbContext database = new AppDbContext())
            {
                var studentsList = from s in database.Students select s;
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                foreach (var student in studentsList)
                {
                    students.Add(student);
                }
                studentsField.ItemsSource = students;
            }
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void CreateStudent_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow window = new CreateWindow
            {
                Owner = this
            };
            window.ShowDialog();
            FillDataGrid();
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (studentsField.SelectedItem != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы точно хотите удалить этого студента?", 
                                                                    "Delete Confirmation", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    using (AppDbContext database = new AppDbContext())
                    {
                        var student = (Student)studentsField.SelectedItem;
                        database.Students.Remove(database.Students.Find(student.Id));
                        database.SaveChanges();
                    }
                    FillDataGrid();
                } 
                else
                {
                    FillDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Студент не выбран");
            }
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (studentsField.SelectedItem != null)
            {
                using (AppDbContext database = new AppDbContext())
                {
                    var student = (Student)studentsField.SelectedItem;
                    CreateWindow window = new CreateWindow
                    {
                        Owner = this
                    };
                    window.tbName.Text += student.Name;
                    window.tbSurname.Text += student.Surname;
                    window.tbAge.Text += student.Age;
                    window.tbGroup.Text += student.GroupNumber;
                    window.idSt.Text += student.Id;
                    if (student.Photo != null)
                    {
                        window.studentPhoto.Source = BytesToImage(student.Photo);
                    }
                    window.ShowDialog();
                   /* database.Students.Remove(database.Students.Find(student.Id));*/
                    database.SaveChanges();
                }
                FillDataGrid();
            }
            else
            {
                MessageBox.Show("Студент не выбран");
            }
        }

        private BitmapSource BytesToImage(byte[] byteArrayIn)
        {
            MemoryStream stream = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length)
            {
                Position = 0
            };
            BitmapImage result = new BitmapImage();
            result.BeginInit();
            result.CacheOption = BitmapCacheOption.OnLoad;
            result.StreamSource = stream;
            result.EndInit();
            result.Freeze();
            return result;
        }

        private void SurnameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (AppDbContext database = new AppDbContext())
            {
                var studentsList = from s in database.Students select s;
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                foreach (var student in studentsList)
                {
                    if (student.Surname.Contains(surnameFilter.Text))
                    {
                        students.Add(student);
                    }
                    returnBtn.IsEnabled = true;
                }
                studentsField.ItemsSource = students;
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
            surnameFilter.Text = "";
            returnBtn.IsEnabled = false;
        }

    }

}
