using System.Data.Entity;
using EducationDB.connection;
using EducationDB.entity;

namespace EducationDB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("students_db_connection")
        {
        }

        static AppDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, AppDbInit>());
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<Student> Students { get; set; }
    }

}
