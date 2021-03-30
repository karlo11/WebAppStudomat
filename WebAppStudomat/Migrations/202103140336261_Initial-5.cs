namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Majors", "NameAbbreviation", c => c.String());
            AlterColumn("dbo.Classes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "OIB", c => c.String(nullable: false));
            AlterColumn("dbo.Colleges", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Majors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "JMBAG", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "JMBAG", c => c.String());
            AlterColumn("dbo.Majors", "Name", c => c.String());
            AlterColumn("dbo.Colleges", "Name", c => c.String());
            AlterColumn("dbo.Teachers", "OIB", c => c.String());
            AlterColumn("dbo.Classes", "Name", c => c.String());
            DropColumn("dbo.Majors", "NameAbbreviation");
        }
    }
}
