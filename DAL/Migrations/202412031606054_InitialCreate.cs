namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Case",
                c => new
                    {
                        CaseNumber = c.Int(nullable: false, identity: true),
                        Headline = c.String(),
                        Description = c.String(),
                        DepartmentNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CaseNumber);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CompanyName);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Initials = c.String(nullable: false, maxLength: 128),
                        CprNumber = c.String(nullable: false),
                        Name = c.String(),
                        DepartmentNumber = c.Int(nullable: false),
                        Company_CompanyName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Initials)
                .ForeignKey("dbo.Company", t => t.Company_CompanyName)
                .Index(t => t.Company_CompanyName);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentNumber = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentNumber);
            
            CreateTable(
                "dbo.TimeRegistration",
                c => new
                    {
                        TimeRegistrationId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        EmployeeId = c.String(),
                        CaseNumber = c.Int(),
                    })
                .PrimaryKey(t => t.TimeRegistrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Company_CompanyName", "dbo.Company");
            DropIndex("dbo.Employee", new[] { "Company_CompanyName" });
            DropTable("dbo.TimeRegistration");
            DropTable("dbo.Department");
            DropTable("dbo.Employee");
            DropTable("dbo.Company");
            DropTable("dbo.Case");
        }
    }
}
