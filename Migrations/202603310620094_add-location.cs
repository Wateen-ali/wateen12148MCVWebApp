namespace wateen12148MCVWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "location");
        }
    }
}
