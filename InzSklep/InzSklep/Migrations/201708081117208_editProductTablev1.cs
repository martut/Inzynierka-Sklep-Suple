namespace InzSklep.Migrations.ConfigurationStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProductTablev1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ShortDescription", c => c.String());
            AddColumn("dbo.Products", "ProductQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "IsHot", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsHot");
            DropColumn("dbo.Products", "ProductQuantity");
            DropColumn("dbo.Products", "ShortDescription");
        }
    }
}
