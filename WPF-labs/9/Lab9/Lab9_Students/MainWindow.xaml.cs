using System;
using Lab9.BusinessLayer.Interfaces;
using Lab9.BusinessLayer.Models;
using Lab9.BusinessLayer.Services;
using Lab9_Students.DialogWindows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;
using System.IO;

namespace Lab9_Students
{
    public partial class MainWindow : Window
    {
        ObservableCollection<GroupDto> groups;
        IGroupService groupService;

        public MainWindow()
        {
            InitializeComponent();
            groupService = new GroupService("connection_students");
            groups = groupService.GetAll();
            cBoxGroup.DataContext = groups;
        }
        
        private void AddStudentToGroup_Click(object sender, RoutedEventArgs e)
        {
            StudentDto studentDto = new StudentDto();            
            EditStudent dialogWindow = new EditStudent(studentDto);
            studentDto.DateOfBirth = DateTime.Today;
            bool open = (bool)dialogWindow.ShowDialog();
            if (open)
            {
                GroupDto groupDto = (GroupDto)cBoxGroup.SelectedItem;
                groupService.AddStudentToGroup(groupDto.GroupId, studentDto);
                UpdateControls();
                dialogWindow.Close();
            }
        }
        
        private void RemoveStudentFromGroup_Click(object sender, RoutedEventArgs e)
        {            
            if (cBoxStudent.SelectedItem != null)
            {
                var answer = MessageBox.Show("Удалить студента?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (answer == MessageBoxResult.Yes)
                {
                    var stId = ((StudentDto)cBoxStudent.SelectedItem).StudentId;
                    var grId = ((GroupDto)cBoxGroup.SelectedItem).GroupId;
                    groupService.RemoveStudentFromGroup(grId, stId);
                    UpdateControls();
                }                
            }
            else
            {
                MessageBox.Show("Не выбран студент", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
        private void ChangeStudent_Click(object sender, RoutedEventArgs e)
        {
            if (cBoxStudent.SelectedItem != null)
            {
                EditStudent dialogWindow = new EditStudent((StudentDto)cBoxStudent.SelectedItem, 
                                                     (GroupDto)cBoxGroup.SelectedItem);
                dialogWindow.ShowDialog();
                UpdateControls();
                dialogWindow.Close();
            }
            else
            {
                MessageBox.Show("Не выбран студент", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            EditGroup dialogWindow = new EditGroup();
            dialogWindow.ShowDialog();
            UpdateControls();
            dialogWindow.Close();
        }
        
        private void RemoveGroup_Click(object sender, RoutedEventArgs e)
        {
            var answer = MessageBox.Show("Удалить группу?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (answer == MessageBoxResult.Yes)
            {
                if (cBoxGroup.SelectedItem != null)
                {
                    int groupId = ((GroupDto)cBoxGroup.SelectedItem).GroupId;
                    groupService.DeleteGroup(groupId);
                    UpdateControls();
                    cBoxGroup.SelectedIndex++;
                }
            }
        }
        
        private void ChangeGroup_Click(object sender, RoutedEventArgs e)
        {
            EditGroup dialog = new EditGroup((GroupDto)cBoxGroup.SelectedItem);
            dialog.ShowDialog();
            UpdateControls();
            dialog.Close();
        }

        private void SaveToXml_Click(object sender, RoutedEventArgs e)
        {
            XDocument xdoc = new XDocument();
            XElement groupss = new XElement("groups");           
            foreach (GroupDto g in groups)
            {
                XElement group = new XElement("group");
                XAttribute grIdAttr = new XAttribute("grId", g.GroupId);
                XAttribute priceAttr = new XAttribute("price", g.Price);
                XAttribute specialtyAttr = new XAttribute("specialty", g.Specialty);
                XAttribute startAttr = new XAttribute("start", g.StartDate);
                XAttribute endAttr = new XAttribute("end", g.EndDate);
                ObservableCollection<StudentDto> students = g.Students;
                foreach (StudentDto s in students)
                {
                    XElement student = new XElement("student");
                    XAttribute nameAttr = new XAttribute("name", s.Name);
                    XAttribute birthAttr = new XAttribute("birthday", s.DateOfBirth);
                    XAttribute indiPriceAttr = new XAttribute("indiPrice", s.IndividualPrice);
                    XAttribute photoAttr = new XAttribute("photo", s.Photo);
                    XAttribute discountAttr = new XAttribute("discount", s.HasDiscount);
                    XAttribute idAttr = new XAttribute("stId", s.StudentId);
                    student.Add(nameAttr);
                    student.Add(birthAttr);
                    student.Add(indiPriceAttr);
                    student.Add(photoAttr);
                    student.Add(discountAttr);
                    student.Add(idAttr);
                    group.Add(student);
                }                
                group.Add(grIdAttr);
                group.Add(priceAttr);
                group.Add(specialtyAttr);
                group.Add(startAttr);
                group.Add(endAttr);
                groupss.Add(group);
            }
            xdoc.Add(groupss);
            string path = Path.Combine((new DirectoryInfo(Directory.GetCurrentDirectory())).FullName, "files");
            xdoc.Save(path + "\\students.xml");
            MessageBox.Show("Данные успешно сохранены", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
        private void UpdateControls()
        {
            int index = cBoxGroup.SelectedIndex;
            groupService = new GroupService("connection_students");
            groups = groupService.GetAll();
            cBoxGroup.DataContext = groups;
            cBoxGroup.SelectedIndex = index;
        }

    }

}
