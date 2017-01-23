namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserFileName = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DeadLine = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostFiles",
                c => new
                    {
                        Post_Id = c.Long(nullable: false),
                        File_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.File_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.Files", t => t.File_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.File_Id);
            
            CreateTable(
                "dbo.TaskFiles",
                c => new
                    {
                        Task_Id = c.Long(nullable: false),
                        File_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_Id, t.File_Id })
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .ForeignKey("dbo.Files", t => t.File_Id, cascadeDelete: true)
                .Index(t => t.Task_Id)
                .Index(t => t.File_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskFiles", "File_Id", "dbo.Files");
            DropForeignKey("dbo.TaskFiles", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.PostFiles", "File_Id", "dbo.Files");
            DropForeignKey("dbo.PostFiles", "Post_Id", "dbo.Posts");
            DropIndex("dbo.TaskFiles", new[] { "File_Id" });
            DropIndex("dbo.TaskFiles", new[] { "Task_Id" });
            DropIndex("dbo.PostFiles", new[] { "File_Id" });
            DropIndex("dbo.PostFiles", new[] { "Post_Id" });
            DropTable("dbo.TaskFiles");
            DropTable("dbo.PostFiles");
            DropTable("dbo.Tasks");
            DropTable("dbo.Posts");
            DropTable("dbo.Files");
        }
    }
}
