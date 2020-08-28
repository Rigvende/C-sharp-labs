using Lab9.BusinessLayer.Interfaces;
using Lab9.BusinessLayer.Models;
using Lab9.BusinessLayer.Services;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace Lab9_Students.DialogWindows
{
    public partial class EditGroup : Window
    {
        bool hasGroupId = false;
        int groupId;
        private ObservableCollection<StudentDto> students;

        public EditGroup()
        {
            InitializeComponent();
        }

        public EditGroup(GroupDto groupDto) : this()
        {
            gridGroup.DataContext = groupDto;
            hasGroupId = true;
            groupId = groupDto.GroupId;
            students = groupDto.Students;
            textBoxSpecialty.Text = groupDto.Specialty;
            datePickerStart.SelectedDate = groupDto.StartDate;
            datePickerEnd.SelectedDate = groupDto.EndDate;
            textBoxPrice.Text = Convert.ToString(groupDto.Price, new CultureInfo("en-US"));
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            if (textBoxSpecialty.Text == "" || textBoxPrice.Text == "")
            {
                MessageBox.Show("Не заполнены обязательные поля (*)", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!hasGroupId)
            {
                IGroupService groupService = new GroupService("StudentsLab9_connection");
                GroupDto newGroup = new GroupDto
                {
                    Specialty = textBoxSpecialty.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text, new CultureInfo("en-US"))
                };
                if (datePickerStart.SelectedDate != null)
                {
                    newGroup.StartDate = (DateTime)datePickerStart.SelectedDate;
                }
                else
                {
                    newGroup.StartDate = DateTime.Today;
                }
                if (datePickerEnd.SelectedDate != null)
                {
                    newGroup.EndDate = (DateTime)datePickerEnd.SelectedDate;
                }
                else
                {
                    newGroup.EndDate = DateTime.Today;
                }
                groupService.CreateGroup(newGroup);
                Close();
            }
            else if (hasGroupId)
            {
                IGroupService groupService = new GroupService("StudentsLab9_connection");
                GroupDto editedGroup = new GroupDto
                {
                    Specialty = textBoxSpecialty.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text, new CultureInfo("en-US"))
                };
               
                if (datePickerStart.SelectedDate != null)
                {
                    editedGroup.StartDate = (DateTime)datePickerStart.SelectedDate;
                }
                else
                {
                    editedGroup.StartDate = DateTime.Today;
                }
                if (datePickerEnd.SelectedDate != null)
                {
                    editedGroup.EndDate = (DateTime)datePickerEnd.SelectedDate;
                }
                else
                {
                    editedGroup.EndDate = DateTime.Today;
                }                
                editedGroup.GroupId = groupId;
                editedGroup.Students = students;
                groupService.UpdateGroup(editedGroup);
                Close();
            }
        }

        private void Button_Click_Cansel(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }

}
