using System;
using System.ComponentModel.DataAnnotations;

namespace EducationDB.entity
{
    public abstract class AbstractEntity
    {
        private DateTime _creationDate;
      
        [Required]
        public DateTime CreationDate
        {
            get 
            { 
                return DateTime.SpecifyKind(_creationDate, DateTimeKind.Utc); 
            }
            private set 
            { 
                _creationDate = value; 
            }
        }

        protected AbstractEntity()
        {
            CreationDate = DateTime.UtcNow;
        }

    }

}
