using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TopicEditModel
    {
        public TopicDTO Topic { get; set; }
        
        public List<TopicDTO> Topics { get; set; }
        public int SelectedParent { get; set; }        
        
        public TopicEditModel()
        {
            Topics = new List<TopicDTO>();
        }
    }
}