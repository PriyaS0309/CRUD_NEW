namespace CRUD_NEW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priya : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "ActiveOrNot");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ActiveOrNot", c => c.Boolean(nullable: false));
        }
    }
}
