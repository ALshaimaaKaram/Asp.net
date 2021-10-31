namespace ITI.UserToken.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _int : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Token",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Token", "UserID", "dbo.Users");
            DropIndex("dbo.Token", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Token");
        }
    }
}
