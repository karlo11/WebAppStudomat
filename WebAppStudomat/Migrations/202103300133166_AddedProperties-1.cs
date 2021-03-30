namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProperties1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "HoursOfLectures", c => c.Int());
            AlterColumn("dbo.Classes", "HoursOfAudit", c => c.Int());
            AlterColumn("dbo.Classes", "HoursOfLab", c => c.Int());
            AlterColumn("dbo.Classes", "HoursOfSeminar", c => c.Int());
            AlterColumn("dbo.Classes", "HoursOfConstr", c => c.Int());
            AlterColumn("dbo.Classes", "HoursOfHomework", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "HoursOfHomework", c => c.Int(nullable: false));
            AlterColumn("dbo.Classes", "HoursOfConstr", c => c.Int(nullable: false));
            AlterColumn("dbo.Classes", "HoursOfSeminar", c => c.Int(nullable: false));
            AlterColumn("dbo.Classes", "HoursOfLab", c => c.Int(nullable: false));
            AlterColumn("dbo.Classes", "HoursOfAudit", c => c.Int(nullable: false));
            AlterColumn("dbo.Classes", "HoursOfLectures", c => c.Int(nullable: false));
        }
    }
}
