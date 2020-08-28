using Lab9.BusinessLayer.Models;
using System.Collections.ObjectModel;

namespace Lab9.BusinessLayer.Interfaces
{
    public interface IStudentService
    {
        ObservableCollection<StudentDto> GetAll();

        StudentDto Get(int studentId);

        void ChangeStudentGroup(int groupId, int studentId);

        void CreateStudent(StudentDto studentDto);

        void DeleteStudent(int studentId);

        void UpdateStudent(StudentDto studentDto);

    }

}
