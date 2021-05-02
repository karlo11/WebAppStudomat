namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_users2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
