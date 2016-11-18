namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoles : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Providers", "NumOfDonation");
            DropColumn("dbo.Providers", "StarRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "StarRating", c => c.Int(nullable: false));
            AddColumn("dbo.Providers", "NumOfDonation", c => c.Int(nullable: false));
        }
    }
}
