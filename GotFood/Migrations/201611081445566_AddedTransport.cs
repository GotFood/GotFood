namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTransport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharityProfiles", "ProvideTransport", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CharityProfiles", "ProvideTransport");
        }
    }
}
