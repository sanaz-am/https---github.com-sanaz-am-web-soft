namespace Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "JoinDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "JoinDate");
        }
    }
}
