namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmpZip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "AccountBalance", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "SuspendStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "SuspendEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "State", c => c.String());
            AddColumn("dbo.Customers", "CustZip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustZip");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "SuspendEnd");
            DropColumn("dbo.Customers", "SuspendStart");
            DropColumn("dbo.Customers", "AccountBalance");
            DropTable("dbo.Employees");
        }
    }
}
