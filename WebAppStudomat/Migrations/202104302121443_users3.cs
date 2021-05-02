namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
        }
    }
}
