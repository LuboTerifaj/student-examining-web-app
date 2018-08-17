using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TopicViewModel
    {
        public List<TopicDTO> Topics { get; set; }

        public TopicViewModel ()
        {
            Topics = new List<TopicDTO>();
        }
            
    }
}