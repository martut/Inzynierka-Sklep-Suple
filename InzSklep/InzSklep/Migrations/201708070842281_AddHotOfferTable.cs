namespace InzSklep.Migrations.ConfigurationStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHotOfferTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotOffers",
                c => new
                    {
                        HotOfferId = c.Int(nullable: false, identity: true),
                        OfferIMGFile = c.String(),
                        OfferLINQ = c.String(),
                    })
                .PrimaryKey(t => t.HotOfferId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HotOffers");
        }
    }
}
