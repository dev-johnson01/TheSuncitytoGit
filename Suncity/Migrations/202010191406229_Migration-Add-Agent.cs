namespace Suncity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddAgent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgentAccounts",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        OtherName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        PhoneNumber2 = c.String(),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Address2 = c.String(),
                        Occupation = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        RelationshipStatus = c.Int(nullable: false),
                        StateOfOrigin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgentId);
            
            AddColumn("dbo.CustomerAccounts", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAccounts", "Address");
            DropTable("dbo.AgentAccounts");
        }
    }
}
