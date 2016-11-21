namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedScoreBoardProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Providers", "StarRating", c => c.Int(nullable: false));
            DropColumn("dbo.ProviderPosts", "StarRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProviderPosts", "StarRating", c => c.Int(nullable: false));
            DropColumn("dbo.Providers", "StarRating");
        }
    }
}
