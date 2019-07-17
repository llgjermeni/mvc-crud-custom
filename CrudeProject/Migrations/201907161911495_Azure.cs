namespace CrudeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Azure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderProductID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        FabricTypeID = c.Int(nullable: false),
                        CoverTypeID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.OrderProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 50),
                        SchoolName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        ContactPhone = c.String(nullable: false, maxLength: 50),
                        ShippingID = c.Int(nullable: false),
                        OrderStatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
        }
    }
}
