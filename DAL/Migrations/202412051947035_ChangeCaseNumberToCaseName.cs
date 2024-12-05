namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCaseNumberToCaseName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Case", "DepartmentName", c => c.String());
            DropColumn("dbo.Case", "DepartmentNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Case", "DepartmentNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Case", "DepartmentName");
        }
    }
}
