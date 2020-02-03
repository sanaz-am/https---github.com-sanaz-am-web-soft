namespace Security.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeJoin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "JoinDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "JoinDate", c => c.DateTime(nullable: false));
        }
    }
}
