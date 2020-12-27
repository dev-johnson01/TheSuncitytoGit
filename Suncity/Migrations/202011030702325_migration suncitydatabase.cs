namespace Suncity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationsuncitydatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AgentAccounts", newName: "Agents");
            RenameTable(name: "dbo.CustomerAccounts", newName: "Customers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Customers", newName: "CustomerAccounts");
            RenameTable(name: "dbo.Agents", newName: "AgentAccounts");
        }
    }
}
