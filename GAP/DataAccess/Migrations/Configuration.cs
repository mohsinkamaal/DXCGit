namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.GAPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.GAPContext context)
        {
            context.ApplicationUsers.AddOrUpdate(obj => obj.UserName, new ApplicationUser
            {
                UserName = "admin",
                EmailAddress = "admin@dxc.com",
                Password = "123",
                FirstName = "Admin",
                LastName = "Admin",
                UserType = ApplicationUserType.Admin
            });
        }
    }
}
