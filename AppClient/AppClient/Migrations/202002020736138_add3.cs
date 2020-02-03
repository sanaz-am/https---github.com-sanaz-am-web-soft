namespace AppClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Mails", "productid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mails", "productid", c => c.Int(nullable: false));
        }
    }
}
