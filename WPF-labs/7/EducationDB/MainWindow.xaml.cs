using EducationDB.entity;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                MessageBox.Show("Студент не выбран"); 
            }
        }

        private void SurnameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (AppDbContext database = new AppDbContext())
            {
                var studentsList = from s in database.Students select s;
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                foreach (var student in studentsList)
                {
                    if (student.Surname.Contains(surnameFilter.Text)) students.Add(student);
                }
                studentsField.ItemsSource = students;
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

    }

}
