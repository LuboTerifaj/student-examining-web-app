using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentExaminingContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        // public DbSet<User> Users { get; set; } // abstraktna trida

        public StudentExaminingContext() : base("name=DatabaseConnectionString")
        {
           Database.SetInitializer( new MigrateDatabaseToLatestVersion<StudentExaminingContext, Migrations.Configuration>());
        }
    }
}
