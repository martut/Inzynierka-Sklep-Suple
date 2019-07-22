namespace InzSklep.Migrations.ConfigurationStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProductTablev2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ShortDescription", c => c.String(maxLength: 298));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ShortDescription", c => c.String());
        }
    }
}
