namespace AppHarbor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Artist = c.String(),
                        BinaryData = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Songs");
        }
    }
}
