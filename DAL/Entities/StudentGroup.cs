using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class StudentGroup
    {
        public StudentGroup()
        {
            Students = new List<Student>();
            Tests = new List<Test>();
        }

        public int StudentGroupID { get; set; }
        [Required]
        public string Name { get; set; }
        public string RegistrateCode { get; set; }

        public List<Student> Students { get; set; }
        public List<Test> Tests { get; set; }     
    }
}
