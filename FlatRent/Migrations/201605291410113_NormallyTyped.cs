namespace FlatRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NormallyTyped : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "Flat_ID", "dbo.Flats");
            DropIndex("dbo.Pictures", new[] { "Flat_ID" });
            RenameColumn(table: "dbo.Pictures", name: "Flat_ID", newName: "FlatId");
            AddColumn("dbo.Flats", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Flats", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Pictures", "FlatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "FlatId");
            AddForeignKey("dbo.Pictures", "FlatId", "dbo.Flats", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "FlatId", "dbo.Flats");
            DropIndex("dbo.Pictures", new[] { "FlatId" });
            AlterColumn("dbo.Pictures", "FlatId", c => c.Int());
            DropColumn("dbo.Flats", "Longtitude");
            DropColumn("dbo.Flats", "Latitude");
            RenameColumn(table: "dbo.Pictures", name: "FlatId", newName: "Flat_ID");
            CreateIndex("dbo.Pictures", "Flat_ID");
            AddForeignKey("dbo.Pictures", "Flat_ID", "dbo.Flats", "ID");
        }
    }
}
