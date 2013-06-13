namespace IdeablogClear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_version : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Language = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.TopicId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .Index(t => t.CreatedBy_UserId);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        CreatedBy_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Users", t => t.CreatedBy_UserId)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.CreatedBy_UserId)
                .Index(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Replies", new[] { "TopicId" });
            DropIndex("dbo.Replies", new[] { "CreatedBy_UserId" });
            DropIndex("dbo.Topics", new[] { "CreatedBy_UserId" });
            DropForeignKey("dbo.Replies", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Replies", "CreatedBy_UserId", "dbo.Users");
            DropForeignKey("dbo.Topics", "CreatedBy_UserId", "dbo.Users");
            DropTable("dbo.Replies");
            DropTable("dbo.Topics");
            DropTable("dbo.Users");
        }
    }
}
