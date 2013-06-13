namespace IdeablogClear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class topic_created_at_computed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topics", "CreatedAt", c => c.DateTime(nullable: false, defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topics", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
