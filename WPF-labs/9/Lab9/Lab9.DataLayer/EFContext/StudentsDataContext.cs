using Lab9.DataLayer.Entities;
using System.Data.Entity;

namespace Lab9.DataLayer.EFContext
{
    public class StudentsDataContext : DbContext
    {
        public StudentsDataContext(string name) : base(name)
        {
            Database.SetInitializer(new StudentsDataInit());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }

}
