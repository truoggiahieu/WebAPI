namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        PMId = c.Int(nullable: false, identity: true),
                        CardOwnerName = c.String(nullable: false, maxLength: 100),
                        CardNumber = c.String(nullable: false, maxLength: 16),
                        ExpirationDate = c.String(nullable: false, maxLength: 5),
                        CVV = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.PMId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentDetails");
        }
    }
}
