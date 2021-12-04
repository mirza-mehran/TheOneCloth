namespace TheOneCloth.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ShortCode = c.String(nullable: false, maxLength: 10),
                        Title = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Countries");
        }
    }
}
