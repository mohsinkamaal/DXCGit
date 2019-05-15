namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 10, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 30, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 10, unicode: false),
                        EmailAddress = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 30, unicode: false),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserName)
                .Index(t => t.EmailAddress, unique: true);
            
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_Of_Crime = c.String(nullable: false, maxLength: 30, unicode: false),
                        Suspect_Name = c.String(maxLength: 30, unicode: false),
                        Details = c.String(maxLength: 150, unicode: false),
                        Incident_Date_And_Time = c.DateTime(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Information_Source = c.String(nullable: false, maxLength: 100, unicode: false),
                        Additional_Information = c.String(nullable: false, maxLength: 1500),
                        Status = c.Int(nullable: false),
                        UserName = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserName)
                .Index(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complaints", "UserName", "dbo.ApplicationUsers");
            DropIndex("dbo.Complaints", new[] { "UserName" });
            DropIndex("dbo.ApplicationUsers", new[] { "EmailAddress" });
            DropTable("dbo.Complaints");
            DropTable("dbo.ApplicationUsers");
        }
    }
}
