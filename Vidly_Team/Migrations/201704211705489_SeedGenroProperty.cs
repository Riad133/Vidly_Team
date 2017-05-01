namespace Vidly_Team.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenroProperty : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (id,name) values (1,'Comedy')");
             Sql("insert into Genres (id,name) values (2,'Action')");
             Sql("insert into Genres (id,name) values (3,'Family')");
             Sql("insert into Genres (id,name) values (4,'Thriller')");

        }
        
        public override void Down()
        {
        }
    }
}
