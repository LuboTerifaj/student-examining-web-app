namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestChanged01 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tests", "MaxTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "MaxTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
