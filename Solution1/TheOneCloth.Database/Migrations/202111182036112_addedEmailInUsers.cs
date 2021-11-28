﻿namespace TheOneCloth.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEmailInUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
        }
    }
}
