namespace CarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "CarType_Id", c => c.Byte(nullable: false));
            AddColumn("dbo.Cars", "CarType_Id1", c => c.Byte());
            CreateIndex("dbo.Cars", "CarType_Id1");
            AddForeignKey("dbo.Cars", "CarType_Id1", "dbo.CarTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarType_Id1", "dbo.CarTypes");
            DropIndex("dbo.Cars", new[] { "CarType_Id1" });
            DropColumn("dbo.Cars", "CarType_Id1");
            DropColumn("dbo.Cars", "CarType_Id");
            DropTable("dbo.CarTypes");
        }
    }
}
