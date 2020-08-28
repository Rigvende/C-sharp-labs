using Lab9.BusinessLayer.Models;
using System.Collections.ObjectModel;

namespace Lab9.BusinessLayer.Interfaces
{
    public interface IGroupService
    {
        ObservableCollection<GroupDto> GetAll();

        GroupDto Get(int id);

        void AddStudentToGroup(int groupId, StudentDto studentDto);

        void RemoveStudentFromGroup(int groupId, int studentId);

        void CreateGroup(GroupDto groupDto);

        void DeleteGroup(int groupId);

        void UpdateGroup(GroupDto groupDto);

    }

}
