namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Question_QuestionID = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionID)
                .Index(t => t.Question_QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Explanation = c.String(),
                        Topic_TopicID = c.Int(),
                        Test_TestID = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Topics", t => t.Topic_TopicID)
                .ForeignKey("dbo.Tests", t => t.Test_TestID)
                .Index(t => t.Topic_TopicID)
                .Index(t => t.Test_TestID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SuperiorTopic_TopicID = c.Int(),
                    })
                .PrimaryKey(t => t.TopicID)
                .ForeignKey("dbo.Topics", t => t.SuperiorTopic_TopicID)
                .Index(t => t.SuperiorTopic_TopicID);
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        StudentGroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RegistrateCode = c.String(),
                    })
                .PrimaryKey(t => t.StudentGroupID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TimeFrom = c.DateTime(nullable: false),
                        TimeTo = c.DateTime(nullable: false),
                        MaxTime = c.Time(nullable: false, precision: 7),
                        GroupOfStudents_StudentGroupID = c.Int(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.TestID)
                .ForeignKey("dbo.StudentGroups", t => t.GroupOfStudents_StudentGroupID)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.GroupOfStudents_StudentGroupID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            CreateTable(
                "dbo.StudentStudentGroups",
                c => new
                    {
                        Student_StudentID = c.Int(nullable: false),
                        StudentGroup_StudentGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentID, t.StudentGroup_StudentGroupID })
                .ForeignKey("dbo.Students", t => t.Student_StudentID, cascadeDelete: true)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroup_StudentGroupID, cascadeDelete: true)
                .Index(t => t.Student_StudentID)
                .Index(t => t.StudentGroup_StudentGroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.Questions", "Test_TestID", "dbo.Tests");
            DropForeignKey("dbo.Tests", "GroupOfStudents_StudentGroupID", "dbo.StudentGroups");
            DropForeignKey("dbo.StudentStudentGroups", "StudentGroup_StudentGroupID", "dbo.StudentGroups");
            DropForeignKey("dbo.StudentStudentGroups", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.Questions", "Topic_TopicID", "dbo.Topics");
            DropForeignKey("dbo.Topics", "SuperiorTopic_TopicID", "dbo.Topics");
            DropForeignKey("dbo.Answers", "Question_QuestionID", "dbo.Questions");
            DropIndex("dbo.StudentStudentGroups", new[] { "StudentGroup_StudentGroupID" });
            DropIndex("dbo.StudentStudentGroups", new[] { "Student_StudentID" });
            DropIndex("dbo.Tests", new[] { "Student_StudentID" });
            DropIndex("dbo.Tests", new[] { "GroupOfStudents_StudentGroupID" });
            DropIndex("dbo.Topics", new[] { "SuperiorTopic_TopicID" });
            DropIndex("dbo.Questions", new[] { "Test_TestID" });
            DropIndex("dbo.Questions", new[] { "Topic_TopicID" });
            DropIndex("dbo.Answers", new[] { "Question_QuestionID" });
            DropTable("dbo.StudentStudentGroups");
            DropTable("dbo.Teachers");
            DropTable("dbo.Tests");
            DropTable("dbo.Students");
            DropTable("dbo.StudentGroups");
            DropTable("dbo.Topics");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
