namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharityProfiles",
                c => new
                    {
                        CharityID = c.Int(nullable: false, identity: true),
                        CharityName = c.String(nullable: false),
                        StreetNumber = c.String(),
                        StreetName = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        MissionStatement = c.String(),
                        ContactName = c.String(),
                        ContactPosition = c.String(),
                        ContactPhone = c.String(nullable: false),
                        ContactEmail = c.String(nullable: false),
                        AdditionalContactInfo = c.String(),
                        GenFoodRequest = c.String(),
                        CharityNum = c.String(nullable: false),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.CharityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CharityProfiles");
        }
    }
}
