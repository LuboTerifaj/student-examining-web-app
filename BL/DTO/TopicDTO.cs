using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO
{
    public class TopicDTO
    {
        public TopicDTO()
        {
            InferiorTopics = new List<TopicDTO>();
            Questions = new List<QuestionDTO>();
        }

        public int TopicID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Superior topic")]
        public TopicDTO SuperiorTopic { get; set; }
        public List<TopicDTO> InferiorTopics { get; set; }

        public List<QuestionDTO> Questions { get; set; }
    }
}
