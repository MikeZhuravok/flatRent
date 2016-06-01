namespace FlatRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRentEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FlatId = c.Int(nullable: false),
                        StartOfRent = c.DateTime(nullable: false),
                        EndOfRent = c.DateTime(nullable: false),
                        RentingUser_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Flats", t => t.FlatId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.RentingUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.FlatId)
                .Index(t => t.RentingUser_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rents", "RentingUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rents", "FlatId", "dbo.Flats");
            DropIndex("dbo.Rents", new[] { "User_Id" });
            DropIndex("dbo.Rents", new[] { "RentingUser_Id" });
            DropIndex("dbo.Rents", new[] { "FlatId" });
            DropTable("dbo.Rents");
        }
    }
}
