namespace EntityDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        Duration = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        EventType = c.String(),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.UserEventMappings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmailId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEventMappings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserEventMappings", "EventId", "dbo.Events");
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropIndex("dbo.UserEventMappings", new[] { "EventId" });
            DropIndex("dbo.UserEventMappings", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserEventMappings");
            DropTable("dbo.Events");
            DropTable("dbo.Comments");
        }
    }
}
