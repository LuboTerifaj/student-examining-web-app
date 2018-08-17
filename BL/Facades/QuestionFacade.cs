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
    public class QuestionFacade
    {

        private readonly StudentExaminingContext context;

        public QuestionFacade(StudentExaminingContext context)
        {
            this.context = context;
        }
        public int CreateQuestion (QuestionDTO question, int topicID)
        {
            Question newQuestion = Mapping.Mapper.Map<Question>(question);
            Topic topic = context.Topics.Find(topicID);
            newQuestion.Topic = topic;

            context.Database.Log = Console.WriteLine;
            context.Questions.Add(newQuestion);                
            context.SaveChanges();
            return newQuestion.QuestionID;            
        }

        public void EditQuestion(QuestionDTO question, int topicID)
        {
            var toEdit = context.Questions.Find(question.QuestionID);

            toEdit.Explanation = question.Explanation;
            toEdit.Description = question.Description;
            toEdit.Points = question.Points;
            toEdit.Type = question.Type;

            toEdit.Topic = context.Topics.Find(topicID);

            context.Entry(toEdit).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteQuestion (QuestionDTO question)
        {
            Question toDelete = Mapping.Mapper.Map<Question>(question);
            context.Database.Log = Console.WriteLine;
            context.Entry(toDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void DeleteQuestion (int ID)
        {
            context.Database.Log = Console.WriteLine;

            var question = new Question();
            foreach(var item in context.Questions.Include(x => x.Topic)
                                                .Include(x => x.Answers))
            {
                if (item.QuestionID == ID)
                {
                    question = item;
                }
            }       

            question.Topic.Questions.Remove(question);
            
            List<Answer> answers = new List<Answer>();
            foreach(var item in context.Questions.Include(x => x.Answers))
            {
                if(item.QuestionID == question.QuestionID)
                {
                    foreach (var i in item.Answers)
                    {
                        answers.Add(context.Answers.Find(i.AnswerID));
                    }
                }
                
            }
            foreach(var item in answers)
            {
                context.Answers.Remove(item);
            }            

            question.Answers.Clear();

            context.Questions.Remove(question);
            context.SaveChanges();
        }

        public QuestionDTO GetQuestionByID(int ID)
        {
            context.Database.Log = Console.WriteLine;
            Question question = new Question();
            foreach(var item in context.Questions.Include(x => x.Answers).Include(x => x.Topic))
            {
                if (item.QuestionID == ID)
                {
                    question = item;
                }
            }
            //var question = context.Questions.Find(ID);
            return Mapping.Mapper.Map<QuestionDTO>(question);
        }
        
        public List<QuestionDTO> GetAllQuestions()
        {
            var questions = new List<QuestionDTO>();
            foreach (var item in context.Questions.Include(x => x.Topic).Include(y => y.Answers).Include(z=>z.Tests))
            {
                questions.Add(Mapping.Mapper.Map<QuestionDTO>(item));
            }
            return questions;
        }
        
    }
}
