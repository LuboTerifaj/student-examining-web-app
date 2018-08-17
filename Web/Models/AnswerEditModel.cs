using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class AnswerEditModel
    {
        public AnswerEditModel()
        {

        }

        public AnswerDTO Answer { get; set; }
        public int QuestionID { get; set; }
    }
}