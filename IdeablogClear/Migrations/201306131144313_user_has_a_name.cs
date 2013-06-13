namespace IdeablogClear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_has_a_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Name");
        }
    }
}
