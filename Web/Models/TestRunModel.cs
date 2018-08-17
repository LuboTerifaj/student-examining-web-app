using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TestRunModel
    {
        public TestRunModel()
        {
            MarkedAnswers = new Dictionary<int, bool>();
            TestResult = new TestResultDTO();            
        }

        public TestDTO Test { get; set; }
        public Dictionary<int, bool> MarkedAnswers { get; set; }

        public TestResultDTO TestResult { get; set; }      
    }
}