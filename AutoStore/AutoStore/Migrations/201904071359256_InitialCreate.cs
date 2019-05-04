namespace AutoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autoes",
                c => new
                    {
                        AutoId = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Description = c.String(),
                        Category = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.AutoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Autoes");
        }
    }
}
