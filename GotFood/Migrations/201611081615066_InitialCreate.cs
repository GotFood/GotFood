namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ProviderID = c.Int(nullable: false, identity: true),
                        OrgName = c.String(),
                        ContactName = c.String(),
                        ContactEmail = c.String(),
                        ContactPhone = c.String(),
                        StreetNumber = c.String(),
                        StreetName = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Providers", "TypeID", "dbo.ProviderTypes");
            DropForeignKey("dbo.Providers", "TranspoID", "dbo.ProviderTransportations");
            DropIndex("dbo.Providers", new[] { "TranspoID" });
            DropIndex("dbo.Providers", new[] { "TypeID" });
            DropTable("dbo.ProviderTypes");
            DropTable("dbo.ProviderTransportations");
            DropTable("dbo.Providers");
        }
    }
}
