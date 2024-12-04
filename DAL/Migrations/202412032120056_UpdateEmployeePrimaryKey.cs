namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeePrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.Employee", "Initials", c => c.String());
            AlterColumn("dbo.Employee", "CprNumber", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Employee", "CprNumber");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employee");
            AlterColumn("dbo.Employee", "CprNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "Initials", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Employee", "Initials");
        }
    }
}
