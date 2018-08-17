using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            Questions = new List<QuestionDTO>();
        }

        public List<QuestionDTO> Questions { get; set; }
    }
}