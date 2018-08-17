using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class StudentDTO
    {
        public StudentDTO() : base()
        {
            StudentGroups = new List<StudentGroupDTO>();
            Tests = new List<TestDTO>();
        }

        public int StudentID { get; set; }

        public List<StudentGroupDTO> StudentGroups { get; set; }
        public List<TestDTO> Tests { get; set; }
    }
}
