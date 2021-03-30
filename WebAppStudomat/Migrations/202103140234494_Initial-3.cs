namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(),
                        ClassID = c.Int(),
                        GradeInt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(),
                        ClassID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID)
                .Index(t => t.ClassID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentClasses", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentClasses", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.Grades", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Grades", "ClassID", "dbo.Classes");
            DropIndex("dbo.StudentClasses", new[] { "ClassID" });
            DropIndex("dbo.StudentClasses", new[] { "StudentID" });
            DropIndex("dbo.Grades", new[] { "ClassID" });
            DropIndex("dbo.Grades", new[] { "StudentID" });
            DropTable("dbo.StudentClasses");
            DropTable("dbo.Grades");
        }
    }
}
