namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryingToUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProviderPosts", "StarRating", c => c.Int(nullable: false));
            AddColumn("dbo.Providers", "NumOfDonation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Providers", "NumOfDonation");
            DropColumn("dbo.ProviderPosts", "StarRating");
        }
    }
}
