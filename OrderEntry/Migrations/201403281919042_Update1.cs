namespace OrderEntry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        CheckID = c.Int(nullable: false, identity: true),
                        BankNo = c.Int(nullable: false),
                        AccountNo = c.Int(nullable: false),
                        CheckNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CheckID);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CardType = c.String(nullable: false),
                        CardNo = c.Int(nullable: false),
                        ExpDate = c.DateTime(nullable: false),
                        CvcCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductNumber = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(),
                        NetAvailable = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Tenders",
                c => new
                    {
                        TenderID = c.Int(nullable: false, identity: true),
                        TenderType = c.String(nullable: false),
                        TenderAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Check_CheckID = c.Int(),
                        CreditCard_CreditCardID = c.Int(),
                        Order_OrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TenderID)
                .ForeignKey("dbo.Checks", t => t.Check_CheckID)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_CreditCardID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .Index(t => t.Check_CheckID)
                .Index(t => t.CreditCard_CreditCardID)
                .Index(t => t.Order_OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenders", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Tenders", "CreditCard_CreditCardID", "dbo.CreditCards");
            DropForeignKey("dbo.Tenders", "Check_CheckID", "dbo.Checks");
            DropIndex("dbo.Tenders", new[] { "Order_OrderID" });
            DropIndex("dbo.Tenders", new[] { "CreditCard_CreditCardID" });
            DropIndex("dbo.Tenders", new[] { "Check_CheckID" });
            DropTable("dbo.Tenders");
            DropTable("dbo.Products");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Checks");
        }
    }
}
