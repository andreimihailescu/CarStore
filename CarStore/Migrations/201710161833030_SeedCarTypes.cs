namespace CarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedCarTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CarTypes (Id, Name) VALUES (1, 'Coupe')");
            Sql("INSERT INTO CarTypes (Id, Name) VALUES (2, 'SUV')");
            Sql("INSERT INTO CarTypes (Id, Name) VALUES (3, 'Sport')");
        }

        public override void Down()
        {
        }
    }
}
