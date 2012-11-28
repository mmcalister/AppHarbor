namespace AppHarbor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        HomeAddress_Line1 = c.String(),
                        HomeAddress_Line2 = c.String(),
                        HomeAddress_City = c.String(),
                        HomeAddress_State = c.String(),
                        HomeAddress_PostalCode = c.String(),
                        HomeAddress_Country = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
