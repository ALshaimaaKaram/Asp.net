namespace ITI.UserTokenAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Users", "Mobile", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Mobile");
            DropColumn("dbo.Users", "Address");
        }
    }
}
