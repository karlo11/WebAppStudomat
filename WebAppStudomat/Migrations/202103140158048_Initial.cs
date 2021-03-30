namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfECTS = c.Int(nullable: false),
                        Details = c.String(),
                        Major_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Majors", t => t.Major_ID)
                .Index(t => t.Major_ID);
            
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        College_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Colleges", t => t.College_ID)
                .Index(t => t.College_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        JMBAG = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfEnrollment = c.DateTime(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        Class_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.Class_ID)
                .Index(t => t.Class_ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OIB = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Colleges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TeacherClasses",
                c => new
                    {
                        Teacher_ID = c.Int(nullable: false),
                        Class_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_ID, t.Class_ID })
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_ID, cascadeDelete: true)
                .Index(t => t.Teacher_ID)
                .Index(t => t.Class_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Majors", "College_ID", "dbo.Colleges");
            DropForeignKey("dbo.TeacherClasses", "Class_ID", "dbo.Classes");
            DropForeignKey("dbo.TeacherClasses", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.Students", "Class_ID", "dbo.Classes");
            DropForeignKey("dbo.Classes", "Major_ID", "dbo.Majors");
            DropIndex("dbo.TeacherClasses", new[] { "Class_ID" });
            DropIndex("dbo.TeacherClasses", new[] { "Teacher_ID" });
            DropIndex("dbo.Students", new[] { "Class_ID" });
            DropIndex("dbo.Majors", new[] { "College_ID" });
            DropIndex("dbo.Classes", new[] { "Major_ID" });
            DropTable("dbo.TeacherClasses");
            DropTable("dbo.Colleges");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Majors");
            DropTable("dbo.Classes");
        }
    }
}
