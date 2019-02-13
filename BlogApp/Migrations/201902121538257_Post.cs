namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "ShortContent", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Posts", "ShortContent", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Posts", "ImageUrl", c => c.String());
        }
    }
}
