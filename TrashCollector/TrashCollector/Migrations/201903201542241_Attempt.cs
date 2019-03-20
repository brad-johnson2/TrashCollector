namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attempt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationUserId" });
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropColumn("dbo.Customers", "ApplicationUserId");
            DropColumn("dbo.Employees", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Customers", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "ApplicationUserId");
            CreateIndex("dbo.Customers", "ApplicationUserId");
            AddForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
