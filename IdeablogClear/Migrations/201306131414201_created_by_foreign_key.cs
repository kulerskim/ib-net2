namespace IdeablogClear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class created_by_foreign_key : DbMigration
    {
        public override void Up()
        {

            DropColumn(table: "dbo.Topics", name: "CreatedById");
            DropColumn(table: "dbo.Replies", name: "CreatedById");

            DropForeignKey("dbo.Topics", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Replies", "CreatedBy_UserId", "dbo.Users");
            DropIndex("dbo.Topics", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.Replies", new[] { "CreatedBy_UserId" });

            RenameColumn(table: "dbo.Topics", name: "CreatedBy_UserId", newName: "CreatedById");
            RenameColumn(table: "dbo.Replies", name: "CreatedBy_UserId", newName: "CreatedById");
            
            AddForeignKey("dbo.Topics", "CreatedById", "dbo.Users", "UserId", cascadeDelete: false);
            AddForeignKey("dbo.Replies", "CreatedById", "dbo.Users", "UserId", cascadeDelete: false);
            CreateIndex("dbo.Topics", "CreatedById");
            CreateIndex("dbo.Replies", "CreatedById");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Replies", new[] { "CreatedById" });
            DropIndex("dbo.Topics", new[] { "CreatedById" });
            DropForeignKey("dbo.Replies", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Topics", "CreatedById", "dbo.Users");
            RenameColumn(table: "dbo.Replies", name: "CreatedById", newName: "CreatedBy_UserId");
            RenameColumn(table: "dbo.Topics", name: "CreatedById", newName: "CreatedBy_UserId");
            CreateIndex("dbo.Replies", "CreatedBy_UserId");
            CreateIndex("dbo.Topics", "CreatedBy_UserId");
            AddForeignKey("dbo.Replies", "CreatedBy_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Topics", "CreatedBy_UserId", "dbo.Users", "UserId");
        }
    }
}
