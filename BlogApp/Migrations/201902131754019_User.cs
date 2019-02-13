namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AlterColumn("dbo.Posts", "ImageUrl", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Posts", "ShortContent", c => c.String());
            AlterColumn("dbo.Posts", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "ShortContent", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "ImageUrl", c => c.String(nullable: false));
            DropTable("dbo.Users");
        }
    }
}
