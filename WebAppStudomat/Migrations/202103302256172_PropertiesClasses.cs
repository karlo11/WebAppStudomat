namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertiesClasses : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Classes", "IsForGrade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "IsForGrade", c => c.Boolean(nullable: false));
        }
    }
}
