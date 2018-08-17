using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class AnswerDTO
    {
        public AnswerDTO ()
        {

        }

        public int AnswerID { get; set; }
        [Required]
        public string Description { get; set; }

        public bool IsCorrect { get; set; }

        public QuestionDTO Question { get; set; }
    }
}
