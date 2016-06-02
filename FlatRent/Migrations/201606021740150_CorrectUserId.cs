namespace FlatRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "RentingUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rents", new[] { "RentingUser_Id" });
            AddColumn("dbo.Rents", "RentingUserId", c => c.String());
            DropColumn("dbo.Rents", "RentingUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "RentingUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Rents", "RentingUserId");
            CreateIndex("dbo.Rents", "RentingUser_Id");
            AddForeignKey("dbo.Rents", "RentingUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
