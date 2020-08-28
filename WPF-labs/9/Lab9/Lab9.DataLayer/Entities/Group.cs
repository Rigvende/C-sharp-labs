using System;
using System.Collections.Generic;

namespace Lab9.DataLayer.Entities
{
    public class Group
    {        
        public int GroupId { get; set; }       
        public string Specialty { get; set; }        
        public decimal Price { get; set; }       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Student> Students { get; set; }

        public Group() : base() {
            Students = new List<Student>();
        }

    }

}