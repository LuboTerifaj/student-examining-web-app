using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Answer
    {
        public Answer ()
        {

        }
        public int AnswerID { get; set; }
        [Required]
        public string Description { get; set; }

        public bool IsCorrect { get; set; }
        
        public Question Question { get; set; }
        //public int QuestionID { get; set; }
    }
}
