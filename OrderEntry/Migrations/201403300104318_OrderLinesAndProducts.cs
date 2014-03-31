namespace OrderEntry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderLinesAndProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lines", "ProductNumber", c => c.String(nullable: false));
            AddColumn("dbo.Lines", "Product_ProductID", c => c.Int());
            AddColumn("dbo.Orders", "NumberOfLines", c => c.Int(nullable: false));
            CreateIndex("dbo.Lines", "Product_ProductID");
            AddForeignKey("dbo.Lines", "Product_ProductID", "dbo.Products", "ProductID");
            DropColumn("dbo.Lines", "Product");
            DropColumn("dbo.Orders", "Lines");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Lines", c => c.Int(nullable: false));
            AddColumn("dbo.Lines", "Product", c => c.String(nullable: false));
            DropForeignKey("dbo.Lines", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Lines", new[] { "Product_ProductID" });
            DropColumn("dbo.Orders", "NumberOfLines");
            DropColumn("dbo.Lines", "Product_ProductID");
            DropColumn("dbo.Lines", "ProductNumber");
        }
    }
}
