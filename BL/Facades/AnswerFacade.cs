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
    public class AnswerFacade
    {

        private readonly StudentExaminingContext context;

        public AnswerFacade(StudentExaminingContext context)
        {
            this.context = context;
        }
        public void CreateAnswer(AnswerDTO answer)
        {
            Answer newAnswer = Mapping.Mapper.Map<Answer>(answer);
            context.Database.Log = Console.WriteLine;
            context.Answers.Add(newAnswer);
            context.SaveChanges();
        }

        public void CreateAnswer(AnswerDTO answer, int questionID)
        {
            Answer newAnswer = Mapping.Mapper.Map<Answer>(answer);
            context.Database.Log = Console.WriteLine;

            var question = context.Questions.Find(questionID);
            newAnswer.Question = question;
            question.Answers.Add(newAnswer);
            
            context.Answers.Add(newAnswer);
            context.SaveChanges();
        }

        public void EditAnswer(AnswerDTO answer)
        {
            var toEdit = Mapping.Mapper.Map<Answer>(answer);
            context.Entry(toEdit).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteAnswer(AnswerDTO answer)
        {
            Answer toDelete = Mapping.Mapper.Map<Answer>(answer);
            context.Database.Log = Console.WriteLine;
            context.Entry(toDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void DeleteAnswer(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var answer = context.Answers.Find(ID);
            context.Answers.Remove(answer);
            context.SaveChanges();
        }

        public AnswerDTO GetAnswerByID(int ID)
        {
            context.Database.Log = Console.WriteLine;
            
            Answer answer = new Answer();
            foreach(var item in context.Answers.Include(x => x.Question))
            {
                if (item.AnswerID == ID)
                {
                    answer = item;
                }
            }
            
           // var answer = context.Answers.Find(ID);
            return Mapping.Mapper.Map<AnswerDTO>(answer);
        }

        public List<AnswerDTO> GetAllAnswers()
        {
            var answers = new List<AnswerDTO>();
            foreach (var item in context.Answers)
            {
                answers.Add(Mapping.Mapper.Map<AnswerDTO>(item));
            }
            return answers;
        }
    }
}
