namespace Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addblogurl4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "sellerId", "dbo.Sellers");
            DropForeignKey("dbo.Products", "GroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.Products", "User_id", "dbo.Users");
            DropForeignKey("dbo.Products", "OrderList_id", "dbo.OrderLists");
            DropForeignKey("dbo.OrderLists", "UserId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "sellerId" });
            DropIndex("dbo.Products", new[] { "GroupId" });
            DropIndex("dbo.Products", new[] { "User_id" });
            DropIndex("dbo.Products", new[] { "OrderList_id" });
            DropIndex("dbo.OrderLists", new[] { "UserId" });
            DropColumn("dbo.Products", "sellerId");
            DropColumn("dbo.Products", "GroupId");
            DropColumn("dbo.Products", "User_id");
            DropColumn("dbo.Products", "OrderList_id");
            DropTable("dbo.Sellers");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.OrderLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderLists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        checkId = c.Int(nullable: false),
                        sent = c.Boolean(nullable: false),
                        date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        state = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        username = c.String(),
                        LogoImg = c.String(),
                        CoverImg = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RePassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Products", "OrderList_id", c => c.Int());
            AddColumn("dbo.Products", "User_id", c => c.Int());
            AddColumn("dbo.Products", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "sellerId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderLists", "UserId");
            CreateIndex("dbo.Products", "OrderList_id");
            CreateIndex("dbo.Products", "User_id");
            CreateIndex("dbo.Products", "GroupId");
            CreateIndex("dbo.Products", "sellerId");
            AddForeignKey("dbo.OrderLists", "UserId", "dbo.Users", "id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "OrderList_id", "dbo.OrderLists", "id");
            AddForeignKey("dbo.Products", "User_id", "dbo.Users", "id");
            AddForeignKey("dbo.Products", "GroupId", "dbo.ProductGroups", "id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "sellerId", "dbo.Sellers", "id", cascadeDelete: true);
        }
    }
}
