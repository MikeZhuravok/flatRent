namespace FlatRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongtitudeAndLatitudeToDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flats", "Longtitude", c => c.Double(false));
            AddColumn("dbo.Flats", "Latitude", c => c.Double(false));
            CreateIndex("dbo.Flats", "Longtitude");
            CreateIndex("dbo.Flats", "Latitude");
        }

        public override void Down()
        {
        }
    }
}
