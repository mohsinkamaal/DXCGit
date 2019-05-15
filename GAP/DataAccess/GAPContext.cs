namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GAPContext : DbContext
    {
        
        public GAPContext()
            : base("name=GAPContext")
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Complaints> Complaints { get; set; }
    }

   
}