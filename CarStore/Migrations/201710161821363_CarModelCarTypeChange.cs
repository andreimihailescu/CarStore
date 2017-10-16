namespace CarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarModelCarTypeChange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cars", name: "CarType_Id1", newName: "CarTypeId");
            RenameIndex(table: "dbo.Cars", name: "IX_CarType_Id1", newName: "IX_CarTypeId");
            DropColumn("dbo.Cars", "CarType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CarType_Id", c => c.Byte(nullable: false));
            RenameIndex(table: "dbo.Cars", name: "IX_CarTypeId", newName: "IX_CarType_Id1");
            RenameColumn(table: "dbo.Cars", name: "CarTypeId", newName: "CarType_Id1");
        }
    }
}
