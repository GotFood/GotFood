namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharityPosts",
                c => new
                    {
                        CharityPostID = c.Int(nullable: false, identity: true),
                        CharityID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        FoodRequested = c.String(nullable: false),
                        WeightRequested = c.Double(nullable: false),
                        PeopleToFeed = c.Int(nullable: false),
                        DateRequested = c.DateTime(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.CharityPostID)
                .ForeignKey("dbo.CharityProfiles", t => t.CharityID, cascadeDelete: true)
                .Index(t => t.CharityID);
            
            CreateTable(
                "dbo.MainFeeds",
                c => new
                    {
                        MainFeedID = c.Int(nullable: false, identity: true),
                        ProviderPostID = c.Int(nullable: false),
                        CharityPostID = c.Int(nullable: false),
                        TransportPostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MainFeedID)
                .ForeignKey("dbo.CharityPosts", t => t.CharityPostID, cascadeDelete: true)
                .ForeignKey("dbo.ProviderPosts", t => t.ProviderPostID, cascadeDelete: true)
                .ForeignKey("dbo.TransportPosts", t => t.TransportPostID, cascadeDelete: true)
                .Index(t => t.ProviderPostID)
                .Index(t => t.CharityPostID)
                .Index(t => t.TransportPostID);
            
            CreateTable(
                "dbo.ProviderPosts",
                c => new
                    {
                        ProviderPostID = c.Int(nullable: false, identity: true),
                        ProviderID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        FoodType = c.String(nullable: false),
                        PeopleFed = c.String(),
                        PotentialAllergens = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        SpecialTransport = c.String(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.ProviderPostID)
                .ForeignKey("dbo.Providers", t => t.ProviderID, cascadeDelete: true)
                .Index(t => t.ProviderID);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ProviderID = c.Int(nullable: false, identity: true),
                        OrgName = c.String(),
                        ContactName = c.String(),
                        ContactEmail = c.String(nullable: false),
                        ContactPhone = c.String(),
                        StreetNumber = c.String(),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Website = c.String(),
                        Foods = c.String(),
                        TypeID = c.Int(nullable: false),
                        TranspoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProviderID)
                .ForeignKey("dbo.ProviderTransportations", t => t.TranspoID, cascadeDelete: true)
                .ForeignKey("dbo.ProviderTypes", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID)
                .Index(t => t.TranspoID);
            
            CreateTable(
                "dbo.ProviderTransportations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Trans = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProviderTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TransportPosts",
                c => new
                    {
                        TransportPostID = c.Int(nullable: false, identity: true),
                        TransportID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        Message = c.String(nullable: false),
                        DateAvailable = c.DateTime(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.TransportPostID)
                .ForeignKey("dbo.Transports", t => t.TransportID, cascadeDelete: true)
                .Index(t => t.TransportID);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        TransportID = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        ContactName = c.String(nullable: false),
                        ContactPosition = c.String(),
                        ContactPhone = c.String(nullable: false),
                        ContactEmail = c.String(nullable: false),
                        AdditionalContactInfo = c.String(),
                        StreetNumber = c.String(),
                        StreetName = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        TransportationTypes = c.String(nullable: false),
                        FoodTypes = c.String(nullable: false),
                        GeneralAvailability = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.TransportID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharityPosts", "CharityID", "dbo.CharityProfiles");
            DropForeignKey("dbo.MainFeeds", "TransportPostID", "dbo.TransportPosts");
            DropForeignKey("dbo.TransportPosts", "TransportID", "dbo.Transports");
            DropForeignKey("dbo.MainFeeds", "ProviderPostID", "dbo.ProviderPosts");
            DropForeignKey("dbo.ProviderPosts", "ProviderID", "dbo.Providers");
            DropForeignKey("dbo.Providers", "TypeID", "dbo.ProviderTypes");
            DropForeignKey("dbo.Providers", "TranspoID", "dbo.ProviderTransportations");
            DropForeignKey("dbo.MainFeeds", "CharityPostID", "dbo.CharityPosts");
            DropIndex("dbo.TransportPosts", new[] { "TransportID" });
            DropIndex("dbo.Providers", new[] { "TranspoID" });
            DropIndex("dbo.Providers", new[] { "TypeID" });
            DropIndex("dbo.ProviderPosts", new[] { "ProviderID" });
            DropIndex("dbo.MainFeeds", new[] { "TransportPostID" });
            DropIndex("dbo.MainFeeds", new[] { "CharityPostID" });
            DropIndex("dbo.MainFeeds", new[] { "ProviderPostID" });
            DropIndex("dbo.CharityPosts", new[] { "CharityID" });
            DropTable("dbo.Transports");
            DropTable("dbo.TransportPosts");
            DropTable("dbo.ProviderTypes");
            DropTable("dbo.ProviderTransportations");
            DropTable("dbo.Providers");
            DropTable("dbo.ProviderPosts");
            DropTable("dbo.MainFeeds");
            DropTable("dbo.CharityPosts");
        }
    }
}
