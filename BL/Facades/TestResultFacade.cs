using BL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class TestResultFacade
    {
        private readonly StudentExaminingContext context;

        public TestResultFacade(StudentExaminingContext context)
        {
            this.context = context;
        }

        public int CreateTestResult(TestResultDTO testResult, Dictionary<int, bool> markedAnswers)
        {
            TestResult newTestResult = Mapping.Mapper.Map<TestResult>(testResult);
            //newTestResult.Test = context.Tests.Find(testResult.Test.TestID);
            
            int points = 0;
            foreach (var item in testResult.Test.Questions)
            {
                int correctAnswersCount = 0;
                foreach (var answer in item.Answers)
                {
                    if (markedAnswers.ContainsKey(answer.AnswerID))
                    {
                       correctAnswersCount += (markedAnswers[answer.AnswerID] == answer.IsCorrect) ? 1 : 0;
                    }
                }
                if (item.Answers.Count == correctAnswersCount)
                {                    
                    points += item.Points;
                }
            }

            newTestResult.Points = points;                        
            
            context.Database.Log = Console.WriteLine;
            var x = context.TestResults.Add(newTestResult);            
            context.SaveChanges();
            return x.TestResultID;
        }

        public TestResultDTO getTestResultByID(int id)
        {
            context.Database.Log = Console.WriteLine;                        
            var testResult = context.TestResults.Find(id);
            return Mapping.Mapper.Map<TestResultDTO>(testResult);
        }
    }
}
