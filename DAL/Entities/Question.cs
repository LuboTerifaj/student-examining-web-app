using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Entities
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
            Tests = new List<Test>();
        }

        public int QuestionID { get; set; }
        [Required]
        public string Description { get; set; }               
        public questionType Type { get; set; }        
        public int Points { get; set; }
        public string Explanation { get; set; }

        public List<Answer> Answers { get; set; }
        public Topic Topic { get; set; }      

        public List<Test> Tests { get; set; }
    }
}
