namespace CRUD_NEW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsActiveToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsActive");
        }
    }
}
