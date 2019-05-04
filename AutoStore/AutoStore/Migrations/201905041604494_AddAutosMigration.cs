namespace AutoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAutosMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Line = c.String(),
                        City = c.String(),
                        GiftWrap = c.Boolean(nullable: false),
                        Dispatched = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        OrderLineId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Auto_AutoId = c.Int(),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderLineId)
                .ForeignKey("dbo.Autoes", t => t.Auto_AutoId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Auto_AutoId)
                .Index(t => t.Order_OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderLines", "Auto_AutoId", "dbo.Autoes");
            DropIndex("dbo.OrderLines", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderLines", new[] { "Auto_AutoId" });
            DropTable("dbo.OrderLines");
            DropTable("dbo.Orders");
        }
    }
}
