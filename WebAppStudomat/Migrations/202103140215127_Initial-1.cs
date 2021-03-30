namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Class_ID", "dbo.Classes");
            DropForeignKey("dbo.TeacherClasses", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.TeacherClasses", "Class_ID", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Class_ID" });
            DropIndex("dbo.TeacherClasses", new[] { "Teacher_ID" });
            DropIndex("dbo.TeacherClasses", new[] { "Class_ID" });
            RenameColumn(table: "dbo.Majors", name: "College_ID", newName: "CollegeID");
            RenameIndex(table: "dbo.Majors", name: "IX_College_ID", newName: "IX_CollegeID");
            AddColumn("dbo.Classes", "Teacher_ID", c => c.Int());
            CreateIndex("dbo.Classes", "Teacher_ID");
            AddForeignKey("dbo.Classes", "Teacher_ID", "dbo.Teachers", "ID");
            DropColumn("dbo.Students", "Class_ID");
            DropTable("dbo.TeacherClasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeacherClasses",
                c => new
                    {
                        Teacher_ID = c.Int(nullable: false),
                        Class_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_ID, t.Class_ID });
            
            AddColumn("dbo.Students", "Class_ID", c => c.Int());
            DropForeignKey("dbo.Classes", "Teacher_ID", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "Teacher_ID" });
            DropColumn("dbo.Classes", "Teacher_ID");
            RenameIndex(table: "dbo.Majors", name: "IX_CollegeID", newName: "IX_College_ID");
            RenameColumn(table: "dbo.Majors", name: "CollegeID", newName: "College_ID");
            CreateIndex("dbo.TeacherClasses", "Class_ID");
            CreateIndex("dbo.TeacherClasses", "Teacher_ID");
            CreateIndex("dbo.Students", "Class_ID");
            AddForeignKey("dbo.TeacherClasses", "Class_ID", "dbo.Classes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TeacherClasses", "Teacher_ID", "dbo.Teachers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Class_ID", "dbo.Classes", "ID");
        }
    }
}
