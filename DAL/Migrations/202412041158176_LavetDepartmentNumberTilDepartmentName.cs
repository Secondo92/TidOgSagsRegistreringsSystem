namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LavetDepartmentNumberTilDepartmentName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "DepartmentName", c => c.String());
            DropColumn("dbo.Employee", "DepartmentNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "DepartmentNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Employee", "DepartmentName");
        }
    }
}
