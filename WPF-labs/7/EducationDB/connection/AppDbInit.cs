using System.Data.Entity.Migrations;

namespace EducationDB.connection
{
    class AppDbInit : DbMigrationsConfiguration<AppDbContext>
    {
        public AppDbInit()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(AppDbContext context)
        {
            base.Seed(context);
        }

    }

}
