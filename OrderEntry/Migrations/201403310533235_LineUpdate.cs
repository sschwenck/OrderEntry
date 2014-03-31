namespace OrderEntry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LineUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lines", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Lines", new[] { "Order_OrderID" });
            AddColumn("dbo.Lines", "OrderNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Lines", "Order_OrderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lines", "Order_OrderID", c => c.Int());
            DropColumn("dbo.Lines", "OrderNumber");
            CreateIndex("dbo.Lines", "Order_OrderID");
            AddForeignKey("dbo.Lines", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
