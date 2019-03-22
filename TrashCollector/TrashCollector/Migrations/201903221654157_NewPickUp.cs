namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPickUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PickUps", "CustomPickUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.PickUps", "PickUpComplete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PickUps", "PickUpComplete");
            DropColumn("dbo.PickUps", "CustomPickUp");
        }
    }
}
