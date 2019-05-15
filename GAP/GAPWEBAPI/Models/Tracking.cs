namespace GAPWEBAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Tracking : DbContext
    {
        public Tracking()
            : base("name=Tracking")
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.Category_Of_Crime)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.Suspect_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.Details)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.Information_Source)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.UserName)
                .IsUnicode(false);
        }
    }
}
