namespace Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addblogurl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatabaseKeys",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DbKey = c.String(),
                        QueryKey = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        Password = c.String(nullable: false),
                        RePassword = c.String(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.DatabaseKeys");
        }
    }
}
