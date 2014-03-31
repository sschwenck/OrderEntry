namespace OrderEntry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderProdutUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "ShipTo_ShipToID", "dbo.ShipToes");
            DropForeignKey("dbo.Orders", "Warehouse_WarehouseID", "dbo.Warehouses");
            DropForeignKey("dbo.Lines", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Orders", new[] { "ShipTo_ShipToID" });
            DropIndex("dbo.Orders", new[] { "Warehouse_WarehouseID" });
            DropIndex("dbo.Lines", new[] { "Product_ProductID" });
            AddColumn("dbo.Orders", "WarehouseNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CustomerNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ShipToNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Lines", "Product_ProductID");
            DropColumn("dbo.Orders", "Customer_CustomerID");
            DropColumn("dbo.Orders", "ShipTo_ShipToID");
            DropColumn("dbo.Orders", "Warehouse_WarehouseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Warehouse_WarehouseID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ShipTo_ShipToID", c => c.Int());
            AddColumn("dbo.Orders", "Customer_CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Lines", "Product_ProductID", c => c.Int());
            DropColumn("dbo.Orders", "ShipToNumber");
            DropColumn("dbo.Orders", "CustomerNumber");
            DropColumn("dbo.Orders", "WarehouseNumber");
            CreateIndex("dbo.Lines", "Product_ProductID");
            CreateIndex("dbo.Orders", "Warehouse_WarehouseID");
            CreateIndex("dbo.Orders", "ShipTo_ShipToID");
            CreateIndex("dbo.Orders", "Customer_CustomerID");
            AddForeignKey("dbo.Lines", "Product_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.Orders", "Warehouse_WarehouseID", "dbo.Warehouses", "WarehouseID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ShipTo_ShipToID", "dbo.ShipToes", "ShipToID");
            AddForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
    }
}
