namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Employees");
            CreateTable(
                "dbo.PickUps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WeekDay = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            AddColumn("dbo.Customers", "CustomerId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employees", "ApplicationUserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Customers", "CustomerId");
            AddPrimaryKey("dbo.Employees", "EmployeeId");
            CreateIndex("dbo.Customers", "ApplicationUserId");
            CreateIndex("dbo.Employees", "ApplicationUserId");
            AddForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PickUps", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.PickUps", new[] { "CustomerId" });
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropIndex("dbo.Customers", new[] { "ApplicationUserId" });
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Employees", "ApplicationUserId");
            DropColumn("dbo.Employees", "EmployeeId");
            DropColumn("dbo.Customers", "ApplicationUserId");
            DropColumn("dbo.Customers", "CustomerId");
            DropTable("dbo.PickUps");
            AddPrimaryKey("dbo.Employees", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
        }
    }
}
