namespace Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addblogurl2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DatabaseKeys", "DbKey", c => c.String(nullable: false));
            AlterColumn("dbo.DatabaseKeys", "QueryKey", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "img", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "img", c => c.String());
            AlterColumn("dbo.Products", "Content", c => c.String());
            AlterColumn("dbo.DatabaseKeys", "QueryKey", c => c.String());
            AlterColumn("dbo.DatabaseKeys", "DbKey", c => c.String());
        }
    }
}
