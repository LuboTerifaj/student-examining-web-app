using BL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TestEditModel
    {
        public TestEditModel()
        {
            Topics = new List<TopicDTO>();
            SelectedTopics = new List<int>();
            StudentGroups = new List<StudentGroupDTO>();
            SelectedStudentGroups = new List<int>();
        }

        public TestDTO Test { get; set; }

        public List<TopicDTO> Topics { get; set; }
        public List<int> SelectedTopics { get; set; }

        public List<StudentGroupDTO> StudentGroups { get; set; }
        public List<int> SelectedStudentGroups { get; set; }

        [Display(Name ="Number of questions")]
        public int NumberOfQuestions { get; set; }


    }    
}