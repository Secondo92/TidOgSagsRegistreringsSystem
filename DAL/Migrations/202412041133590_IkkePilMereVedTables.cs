namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IkkePilMereVedTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TimeRegistration", "Employee_CprNumber", "dbo.Employee");
            DropIndex("dbo.TimeRegistration", new[] { "Employee_CprNumber" });
            DropColumn("dbo.TimeRegistration", "Employee_CprNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeRegistration", "Employee_CprNumber", c => c.String(maxLength: 128));
            CreateIndex("dbo.TimeRegistration", "Employee_CprNumber");
            AddForeignKey("dbo.TimeRegistration", "Employee_CprNumber", "dbo.Employee", "CprNumber");
        }
    }
}
