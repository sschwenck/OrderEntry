namespace OrderEntry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderIdForLines : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lines", "OrderID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lines", "OrderID");
        }
    }
}
