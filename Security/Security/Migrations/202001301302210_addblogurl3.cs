namespace Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addblogurl3 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Products", "User_id", c => c.Int());
            AddColumn("dbo.Products", "OrderList_id", c => c.Int());
            AddForeignKey("dbo.Products", "User_id", "dbo.Users", "id");
            AddForeignKey("dbo.Products", "OrderList_id", "dbo.OrderLists", "id");
            CreateIndex("dbo.Products", "User_id");
            CreateIndex("dbo.Products", "OrderList_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderLists", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "OrderList_id" });
            DropIndex("dbo.Products", new[] { "User_id" });
            DropForeignKey("dbo.OrderLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "OrderList_id", "dbo.OrderLists");
            DropForeignKey("dbo.Products", "User_id", "dbo.Users");
            DropColumn("dbo.Products", "OrderList_id");
            DropColumn("dbo.Products", "User_id");
            DropTable("dbo.OrderLists");
        }
    }
}
