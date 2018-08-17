using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Topic
    {
        public Topic()
        {
            InferiorTopics = new List<Topic>();
            Questions = new List<Question>();
        }

        public int TopicID { get; set; }

        [Required]
        public string Name { get; set; }

        public Topic SuperiorTopic { get; set; }
        public List<Topic> InferiorTopics { get; set; }

        public List<Question> Questions { get; set; }

       // public int QuestionID { get; set; }
    }
}
