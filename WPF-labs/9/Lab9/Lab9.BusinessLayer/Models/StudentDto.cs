using System;

namespace Lab9.BusinessLayer.Models
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Photo { get; set; }

        public decimal IndividualPrice { get; set; }

        public bool HasDiscount { get; set; }

        public int GroupId { get; set; }

    }

}
