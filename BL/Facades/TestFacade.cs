using BL.DTO;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public class TestFacade
    {
        private readonly StudentExaminingContext context;

        public TestFacade(StudentExaminingContext context)
        {
            this.context = context;
        }

        public void CreateTest(TestDTO test)
        {
            Test newTest = Mapping.Mapper.Map<Test>(test);
            context.Database.Log = Console.WriteLine;
            context.Tests.Add(newTest);
            context.SaveChanges();
        }

        public void CreateTest(TestDTO test, List<int> selectedTopics, List<int> selectedStudentGroups, int numberOfQuestions)
        {
            Test newTest = Mapping.Mapper.Map<Test>(test);
            
            var query = context.Topics.Include(x => x.Questions).Include(y => y.Questions.Select(z => z.Answers));

            List<int> topicsHasntQuestionsWithAnswers = new List<int>();
            int topicsQuestionsCount = 0;
            foreach (var item in selectedTopics)
            {
                if (query.Select(x => x).Where(y => y.TopicID == item).FirstOrDefault().Questions.Count > 0 &&
                    query.Select(x => x).Where(y => y.TopicID == item).FirstOrDefault()
                    .Questions.Select(x => x).Where(x => x.Answers.Count > 0).Count() > 0)                                       
                {

                    topicsQuestionsCount += query.Select(x => x).Where(y => y.TopicID == item).FirstOrDefault()
                                            .Questions.Select(x => x).Where(x => x.Answers.Count > 0).Count();
                } else
                {
                    topicsHasntQuestionsWithAnswers.Add(item);
                }
            }
            int questionsCount = (topicsQuestionsCount < numberOfQuestions) ? topicsQuestionsCount : numberOfQuestions;
            foreach(var item in topicsHasntQuestionsWithAnswers)
            {
                selectedTopics.Remove(item);
            }

            Random ran = new Random();
            for (int i = 0; i < questionsCount; i++)
            {
                if (selectedTopics.Count > 0)
                {
                    int rNumber = ran.Next(0, selectedTopics.Count);
                    int topicID = selectedTopics[rNumber];

                    Topic topic = query.Select(x => x).Where(y => y.TopicID == topicID).FirstOrDefault();                        

                    if (topic.Questions.Count > 0)
                    {
                        
                        int rNumber2 = ran.Next(0, topic.Questions.Count);                        

                        if(!newTest.Questions.Contains(topic.Questions[rNumber2]) && topic.Questions[rNumber2].Answers.Count > 0)
                        {
                            newTest.Questions.Add(topic.Questions[rNumber2]);
                        } else
                        {
                            i--;
                        }
                    }                        
                }                   
            }                        

            foreach(var item in selectedStudentGroups)
            {
                newTest.StudentGroups.Add(context.StudentGroups.Find(item));
            }            
            
            context.Database.Log = Console.WriteLine;
            context.Tests.Add(newTest);                     
            context.SaveChanges();            
        }

        public void EditTest(TestDTO test)
        {
            var toEdit = context.Tests.Find(test.TestID);

            toEdit.Name = test.Name;
            toEdit.TimeFrom = test.TimeFrom;
            toEdit.TimeTo = test.TimeTo;

            context.Entry(toEdit).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTest(TestDTO test)
        {
            Test toDelete = Mapping.Mapper.Map<Test>(test);
            context.Database.Log = Console.WriteLine;
            context.Entry(toDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void DeleteTest(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var test = context.Tests.Find(ID);
            context.Tests.Remove(test);
            context.SaveChanges();
        }

        public TestDTO GetTestByID(int ID)
        {
            context.Database.Log = Console.WriteLine;

            var query = context.Tests.Include(x => x.StudentGroups).Include(x => x.Questions)
                                      .Include(x => x.Questions.Select(y => y.Answers));
            var test = query.Select(x=>x).Where(x=> x.TestID == ID).FirstOrDefault();            
            return Mapping.Mapper.Map<TestDTO>(test);
        }

        public List<TestDTO> GetAllTests()
        {
            var tests = new List<TestDTO>();
            foreach (var item in context.Tests.ToList())
            {
                tests.Add(Mapping.Mapper.Map<TestDTO>(item));
            }
            return tests;
        }
    }
}
