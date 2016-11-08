namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Providers", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Providers", "City");
        }
    }
}
