namespace CarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CarType_Id", "dbo.CarTypes");
            DropIndex("dbo.Cars", new[] { "CarType_Id" });
            DropPrimaryKey("dbo.CarTypes");
            AddColumn("dbo.Cars", "CarType_Id1", c => c.Byte());
            AlterColumn("dbo.Cars", "CarType_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.CarTypes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.CarTypes", "Id");
            CreateIndex("dbo.Cars", "CarType_Id1");
            AddForeignKey("dbo.Cars", "CarType_Id1", "dbo.CarTypes", "Id");
            DropColumn("dbo.Cars", "CarTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CarTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Cars", "CarType_Id1", "dbo.CarTypes");
            DropIndex("dbo.Cars", new[] { "CarType_Id1" });
            DropPrimaryKey("dbo.CarTypes");
            AlterColumn("dbo.CarTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cars", "CarType_Id", c => c.Int());
            DropColumn("dbo.Cars", "CarType_Id1");
            AddPrimaryKey("dbo.CarTypes", "Id");
            CreateIndex("dbo.Cars", "CarType_Id");
            AddForeignKey("dbo.Cars", "CarType_Id", "dbo.CarTypes", "Id");
        }
    }
}
