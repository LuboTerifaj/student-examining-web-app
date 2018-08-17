namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestStudentGroups : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "GroupOfStudents_StudentGroupID", "dbo.StudentGroups");
            DropIndex("dbo.Tests", new[] { "GroupOfStudents_StudentGroupID" });
            CreateTable(
                "dbo.TestStudentGroups",
                c => new
                    {
                        Test_TestID = c.Int(nullable: false),
                        StudentGroup_StudentGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_TestID, t.StudentGroup_StudentGroupID })
                .ForeignKey("dbo.Tests", t => t.Test_TestID, cascadeDelete: true)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroup_StudentGroupID, cascadeDelete: true)
                .Index(t => t.Test_TestID)
                .Index(t => t.StudentGroup_StudentGroupID);
            
            DropColumn("dbo.Tests", "GroupOfStudents_StudentGroupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "GroupOfStudents_StudentGroupID", c => c.Int());
            DropForeignKey("dbo.TestStudentGroups", "StudentGroup_StudentGroupID", "dbo.StudentGroups");
            DropForeignKey("dbo.TestStudentGroups", "Test_TestID", "dbo.Tests");
            DropIndex("dbo.TestStudentGroups", new[] { "StudentGroup_StudentGroupID" });
            DropIndex("dbo.TestStudentGroups", new[] { "Test_TestID" });
            DropTable("dbo.TestStudentGroups");
            CreateIndex("dbo.Tests", "GroupOfStudents_StudentGroupID");
            AddForeignKey("dbo.Tests", "GroupOfStudents_StudentGroupID", "dbo.StudentGroups", "StudentGroupID");
        }
    }
}
