namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "ISVUNumber", c => c.String());
            AddColumn("dbo.Classes", "HoursOfLectures", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "HoursOfAudit", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "HoursOfLab", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "HoursOfSeminar", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "HoursOfConstr", c => c.Int(nullable: false));
            AddColumn("dbo.Classes", "IsForGrade", c => c.Boolean(nullable: false));
            AddColumn("dbo.Classes", "HoursOfHomework", c => c.Int(nullable: false));
            AddColumn("dbo.Majors", "ViceDeanFirstName", c => c.String());
            AddColumn("dbo.Majors", "ViceDeanLastName", c => c.String());
            AddColumn("dbo.Teachers", "Address", c => c.String());
            AddColumn("dbo.Teachers", "Email", c => c.String());
            AddColumn("dbo.Colleges", "FoundationYear", c => c.Int(nullable: false));
            AddColumn("dbo.Colleges", "DeanFirstName", c => c.String());
            AddColumn("dbo.Colleges", "DeanLastName", c => c.String());
            AddColumn("dbo.Students", "OIB", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "OIB");
            DropColumn("dbo.Colleges", "DeanLastName");
            DropColumn("dbo.Colleges", "DeanFirstName");
            DropColumn("dbo.Colleges", "FoundationYear");
            DropColumn("dbo.Teachers", "Email");
            DropColumn("dbo.Teachers", "Address");
            DropColumn("dbo.Majors", "ViceDeanLastName");
            DropColumn("dbo.Majors", "ViceDeanFirstName");
            DropColumn("dbo.Classes", "HoursOfHomework");
            DropColumn("dbo.Classes", "IsForGrade");
            DropColumn("dbo.Classes", "HoursOfConstr");
            DropColumn("dbo.Classes", "HoursOfSeminar");
            DropColumn("dbo.Classes", "HoursOfLab");
            DropColumn("dbo.Classes", "HoursOfAudit");
            DropColumn("dbo.Classes", "HoursOfLectures");
            DropColumn("dbo.Classes", "ISVUNumber");
        }
    }
}
