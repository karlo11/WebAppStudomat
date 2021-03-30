namespace WebAppStudomat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Majors", name: "CollegeID", newName: "College_ID");
            RenameIndex(table: "dbo.Majors", name: "IX_CollegeID", newName: "IX_College_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Majors", name: "IX_College_ID", newName: "IX_CollegeID");
            RenameColumn(table: "dbo.Majors", name: "College_ID", newName: "CollegeID");
        }
    }
}
