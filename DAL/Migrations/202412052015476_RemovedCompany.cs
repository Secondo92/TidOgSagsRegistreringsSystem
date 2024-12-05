namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "Company_CompanyName", "dbo.Company");
            DropIndex("dbo.Employee", new[] { "Company_CompanyName" });
            DropColumn("dbo.Employee", "Company_CompanyName");
            DropTable("dbo.Company");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CompanyName);
            
            AddColumn("dbo.Employee", "Company_CompanyName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employee", "Company_CompanyName");
            AddForeignKey("dbo.Employee", "Company_CompanyName", "dbo.Company", "CompanyName");
        }
    }
}
