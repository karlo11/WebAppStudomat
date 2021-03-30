namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Classes", name: "Major_ID", newName: "MajorID");
            RenameColumn(table: "dbo.Classes", name: "Teacher_ID", newName: "TeacherID");
            RenameIndex(table: "dbo.Classes", name: "IX_Teacher_ID", newName: "IX_TeacherID");
            RenameIndex(table: "dbo.Classes", name: "IX_Major_ID", newName: "IX_MajorID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Classes", name: "IX_MajorID", newName: "IX_Major_ID");
            RenameIndex(table: "dbo.Classes", name: "IX_TeacherID", newName: "IX_Teacher_ID");
            RenameColumn(table: "dbo.Classes", name: "TeacherID", newName: "Teacher_ID");
            RenameColumn(table: "dbo.Classes", name: "MajorID", newName: "Major_ID");
        }
    }
}
