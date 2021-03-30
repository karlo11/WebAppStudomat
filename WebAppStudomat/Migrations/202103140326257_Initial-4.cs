namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "DateOfGrade", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentClasses", "DateOfEnrollment", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentClasses", "DateOfEnrollment");
            DropColumn("dbo.Grades", "DateOfGrade");
        }
    }
}
