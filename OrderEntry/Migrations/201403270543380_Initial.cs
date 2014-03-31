namespace OrderEntry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        LineID = c.Int(nullable: false, identity: true),
                        LineNo = c.Int(nullable: false),
                        Product = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        QtyOrd = c.Int(nullable: false),
                        QtyShip = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarginAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarginPct = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.LineID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .Index(t => t.Order_OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        OrderSuffix = c.Int(nullable: false),
                        OrderType = c.String(nullable: false),
                        CustomerPO = c.String(),
                        TakenBy = c.String(),
                        Taxable = c.Boolean(nullable: false),
                        Lines = c.Int(nullable: false),
                        OrderTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TenderedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_CustomerID = c.Int(nullable: false),
                        ShipTo_ShipToID = c.Int(),
                        Warehouse_WarehouseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.ShipToes", t => t.ShipTo_ShipToID)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_WarehouseID, cascadeDelete: true)
                .Index(t => t.Customer_CustomerID)
                .Index(t => t.ShipTo_ShipToID)
                .Index(t => t.Warehouse_WarehouseID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerNumber = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Address_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressID)
                .Index(t => t.Address_AddressID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.ShipToes",
                c => new
                    {
                        ShipToID = c.Int(nullable: false, identity: true),
                        ShipToNo = c.Int(nullable: false),
                        ShipToName = c.String(nullable: false),
                        Address_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.ShipToID)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressID)
                .Index(t => t.Address_AddressID);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WarehouseID = c.Int(nullable: false, identity: true),
                        WarehouseNumber = c.Int(nullable: false),
                        WarehouseName = c.String(nullable: false),
                        Address_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.WarehouseID)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressID)
                .Index(t => t.Address_AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lines", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Warehouse_WarehouseID", "dbo.Warehouses");
            DropForeignKey("dbo.Warehouses", "Address_AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "ShipTo_ShipToID", "dbo.ShipToes");
            DropForeignKey("dbo.ShipToes", "Address_AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses");
            DropIndex("dbo.Lines", new[] { "Order_OrderID" });
            DropIndex("dbo.Orders", new[] { "Warehouse_WarehouseID" });
            DropIndex("dbo.Warehouses", new[] { "Address_AddressID" });
            DropIndex("dbo.Orders", new[] { "ShipTo_ShipToID" });
            DropIndex("dbo.ShipToes", new[] { "Address_AddressID" });
            DropIndex("dbo.Orders", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Customers", new[] { "Address_AddressID" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.ShipToes");
            DropTable("dbo.Addresses");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Lines");
        }
    }
}
