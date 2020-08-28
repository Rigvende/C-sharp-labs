using System;

namespace Lab9.DataLayer.Entities
{
    public class Student
    {        
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Photo { get; set; }
        public decimal IndividualPrice { get; set; }
        public int GroupId { get; set; }       
        public Group Group { get; set; }         

    }

}
