namespace BingeList.Migrations.DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitBingeListDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavouriteMovies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        MovieId = c.String(),
                        movieInfo = c.String(storeType: "xml"),
                        UserHasWatched = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FavouriteMovies");
        }
    }
}
