using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationDB.entity
{
    public class Student : AbstractEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20), Required]
        public string Name { get; set; }

        [MaxLength(20), Required]
        public string Surname { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int GroupNumber { get; set; }

        [MaxLength(1), Required]
        public string Gender { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public Student() : base() { }
    }

}
