using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class TestResultDTO
    {
        public TestResultDTO()
        {

        }

        public int TestResultID { get; set; }

        public int Points { get; set; }

        [Display(Name = "Opened in")]
        //[DataType(DataType.Date)]
        public DateTime OpenedTime { get; set; }

        [Display(Name = "Saved in")]
        //[DataType(DataType.Date)]
        public DateTime SavedTime { get; set; }

        public TestDTO Test { get; set; }
    }
}
