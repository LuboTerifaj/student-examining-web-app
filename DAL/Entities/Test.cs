using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Test
    {
        public Test()
        {
            StudentGroups = new List<StudentGroup>();
            Questions = new List<Question>();
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

        public List<StudentGroup> StudentGroups { get; set; }
        public List<Question> Questions { get; set; }

    }
}
