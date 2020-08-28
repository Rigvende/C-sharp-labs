using System;
using System.Collections.ObjectModel;

namespace Lab9.BusinessLayer.Models
{
    public class GroupDto
    {
        public int GroupId { get; set; }

        public string Specialty { get; set; }

        public decimal Price { get; set; } 
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ObservableCollection<StudentDto> Students { get; set; }

    }

}
