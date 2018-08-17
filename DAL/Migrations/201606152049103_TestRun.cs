namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestRun : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        TestResultID = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        OpenedTime = c.DateTime(nullable: false),
                        SavedTime = c.DateTime(nullable: false),
                        Test_TestID = c.Int(),
                    })
                .PrimaryKey(t => t.TestResultID)
                .ForeignKey("dbo.Tests", t => t.Test_TestID)
                .Index(t => t.Test_TestID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "Test_TestID", "dbo.Tests");
            DropIndex("dbo.TestResults", new[] { "Test_TestID" });
            DropTable("dbo.TestResults");
        }
    }
}
