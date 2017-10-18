namespace CarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowroomToCarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ShowroomId", c => c.Int());
            CreateIndex("dbo.Cars", "ShowroomId");
            AddForeignKey("dbo.Cars", "ShowroomId", "dbo.Showrooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ShowroomId", "dbo.Showrooms");
            DropIndex("dbo.Cars", new[] { "ShowroomId" });
            DropColumn("dbo.Cars", "ShowroomId");
        }
    }
}
