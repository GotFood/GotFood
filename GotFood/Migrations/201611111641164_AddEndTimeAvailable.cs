namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEndTimeAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransportPosts", "StartTimeAvailable", c => c.DateTime(nullable: false));
            AddColumn("dbo.TransportPosts", "EndTimeAvailable", c => c.DateTime(nullable: false));
            DropColumn("dbo.TransportPosts", "DateAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransportPosts", "DateAvailable", c => c.DateTime(nullable: false));
            DropColumn("dbo.TransportPosts", "EndTimeAvailable");
            DropColumn("dbo.TransportPosts", "StartTimeAvailable");
        }
    }
}
