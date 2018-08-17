using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Student : User
    {
        public Student()
        {
            StudentGroups = new List<StudentGroup>();
            Tests = new List<Test>();
        }

        public int StudentID { get; set; }

        public List<StudentGroup> StudentGroups { get; set; }
        public List<Test> Tests { get; set; }
       // public int StudentGroupID { get; set; }
      //  public int TestID { get; set; }
    }
}
