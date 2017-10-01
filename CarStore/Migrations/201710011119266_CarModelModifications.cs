namespace CarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarModelModifications : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "SerialNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "SerialNumber", c => c.String());
        }
    }
}
