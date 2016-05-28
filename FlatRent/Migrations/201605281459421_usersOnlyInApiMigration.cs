namespace FlatRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersOnlyInApiMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flats", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Pictures", "LinkToImage", c => c.String());
            AddColumn("dbo.Pictures", "Flat_ID", c => c.Int());
            CreateIndex("dbo.Flats", "ApplicationUser_Id");
            CreateIndex("dbo.Pictures", "Flat_ID");
            AddForeignKey("dbo.Flats", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Pictures", "Flat_ID", "dbo.Flats", "ID");
            DropColumn("dbo.Pictures", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Image", c => c.Binary());
            DropForeignKey("dbo.Pictures", "Flat_ID", "dbo.Flats");
            DropForeignKey("dbo.Flats", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Pictures", new[] { "Flat_ID" });
            DropIndex("dbo.Flats", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Pictures", "Flat_ID");
            DropColumn("dbo.Pictures", "LinkToImage");
            DropColumn("dbo.Flats", "ApplicationUser_Id");
        }
    }
}
