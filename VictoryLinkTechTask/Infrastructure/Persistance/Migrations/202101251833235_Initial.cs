namespace VictoryLinkTechTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MobileNumber = c.Int(nullable: false),
                        Action = c.String(maxLength: 50),
                        Handled = c.Boolean(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        HandlingDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}
