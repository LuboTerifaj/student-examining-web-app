using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class TestDTO
    {
        public TestDTO()
        {
            StudentGroups = new List<StudentGroupDTO>();
            Questions = new List<QuestionDTO>();
        }

        public int TestID { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Open from")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        //[DataType(DataType.Date)]
        public DateTime TimeFrom { get; set; }

        [Display(Name = "Open to")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        //[DataType(DataType.Date)]
        public DateTime TimeTo { get; set; }

       // public TimeSpan MaxTime { get; set; }

        public List<StudentGroupDTO> StudentGroups { get; set; }        
        public List<QuestionDTO> Questions { get; set; }
    }
}
