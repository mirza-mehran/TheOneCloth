namespace TheOneCloth.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializationDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                        ImageURL = c.String(),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sub_Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sub_category = c.String(),
                        Status = c.String(),
                        CategoriesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoriesID, cascadeDelete: true)
                .Index(t => t.CategoriesID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        Roles = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sub_Category", "CategoriesID", "dbo.Categories");
            DropIndex("dbo.Sub_Category", new[] { "CategoriesID" });
            DropTable("dbo.Users");
            DropTable("dbo.Sub_Category");
            DropTable("dbo.Categories");
        }
    }
}
