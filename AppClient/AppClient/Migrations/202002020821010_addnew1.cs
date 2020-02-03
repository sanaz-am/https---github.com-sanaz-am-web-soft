namespace AppClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnew1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Mails", "date");
            DropColumn("dbo.Users", "JoinDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "JoinDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Mails", "date", c => c.DateTime(nullable: false));
        }
    }
}
