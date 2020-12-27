namespace Suncity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationspassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgentAccounts", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AgentAccounts", "Password");
        }
    }
}
