using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class StudentGroupDTO
    {
        public StudentGroupDTO()
        {
            Students = new List<StudentDTO>();
            Tests = new List<TestDTO>();
        }

        public int StudentGroupID { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Registration code")]
        public string RegistrateCode { get; set; }

        public List<StudentDTO> Students { get; set; }
        public List<TestDTO> Tests { get; set; }
    }
}
