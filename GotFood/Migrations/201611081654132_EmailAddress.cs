namespace GotFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Providers", "ContactEmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Providers", "ContactEmail", c => c.String());
        }
    }
}
