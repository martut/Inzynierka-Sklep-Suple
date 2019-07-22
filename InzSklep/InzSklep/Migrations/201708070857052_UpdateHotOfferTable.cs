namespace InzSklep.Migrations.ConfigurationStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateHotOfferTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HotOffers", "Title", c => c.String());
            AddColumn("dbo.HotOffers", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HotOffers", "Description");
            DropColumn("dbo.HotOffers", "Title");
        }
    }
}
