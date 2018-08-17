using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL.DTO
{
    public class QuestionDTO
    {
        public QuestionDTO()
        {
            Answers = new List<AnswerDTO>();
            Tests = new List<TestDTO>();
        }

        public int QuestionID { get; set; }
        [Required]
        public string Description { get; set; }
        public questionType Type { get; set; }
        public int Points { get; set; }
        public string Explanation { get; set; }

        public List<AnswerDTO> Answers { get; set; }
        public TopicDTO Topic { get; set; }

        public List<TestDTO> Tests { get; set; }
        
    }
}
