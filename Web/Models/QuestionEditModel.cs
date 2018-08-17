using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class QuestionEditModel
    {
        public QuestionEditModel()
        {
            Topics = new List<TopicDTO>();
        }

        public QuestionDTO Question { get; set; }

        public List<TopicDTO> Topics { get; set; }
        public int SelectedTopic { get; set; }

        //public List<AnswerDTO> Answers { get; set; }

    }
}