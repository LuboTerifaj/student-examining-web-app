using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TestViewModel
    {
        public TestViewModel()
        {
            Tests = new List<TestDTO>();
        }

        public List<TestDTO> Tests { get; set; }
    }
}