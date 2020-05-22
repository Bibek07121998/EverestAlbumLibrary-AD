namespace EverestAlbumLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Album : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "AgeRestriction", c => c.String(nullable: false));
            DropTable("dbo.UserTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Albums", "AgeRestriction");
        }
    }
}
