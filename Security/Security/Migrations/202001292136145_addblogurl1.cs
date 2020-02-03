namespace Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addblogurl1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Mark = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Cost = c.String(nullable: false),
                        Content = c.String(),
                        img = c.String(),
                        Offer = c.String(),
                        featureString = c.String(),
                        IsExist = c.Boolean(nullable: false),
                        count = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        sellerId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        seen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Sellers", t => t.sellerId, cascadeDelete: true)
                .ForeignKey("dbo.ProductGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.sellerId)
                .Index(t => t.GroupId);
            
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
            
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        state = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "GroupId" });
            DropIndex("dbo.Products", new[] { "sellerId" });
            DropForeignKey("dbo.Products", "GroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.Products", "sellerId", "dbo.Sellers");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.Sellers");
            DropTable("dbo.Products");
        }
    }
}
