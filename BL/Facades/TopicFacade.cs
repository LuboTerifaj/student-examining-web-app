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
    public class TopicFacade
    {
        
        private readonly StudentExaminingContext context;

        public TopicFacade(StudentExaminingContext context)
        {
            this.context = context;
        }
        

        public void CreateTopic(TopicDTO topic)
        {
            Topic newTopic = Mapping.Mapper.Map<Topic>(topic);
            context.Database.Log = Console.WriteLine;
            context.Topics.Add(newTopic);
            context.SaveChanges();
        }

        public void CreateTopic(TopicDTO topic, int parentID)
        {
            Topic newTopic = Mapping.Mapper.Map<Topic>(topic);
            context.Database.Log = Console.WriteLine;
            context.Topics.Add(newTopic);

            Topic parent = context.Topics.Find(parentID);
            parent.InferiorTopics.Add(newTopic);
            newTopic.SuperiorTopic = parent;

            context.SaveChanges();
        }

        public void EditTopic(TopicDTO topic, int parentID)
        {
            var toEdit = context.Topics.Find(topic.TopicID);

            toEdit.Name = topic.Name;

            Topic parent = context.Topics.Find(parentID);
            parent.InferiorTopics.Add(toEdit);
            toEdit.SuperiorTopic = parent;

            context.Entry(toEdit).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTopic(TopicDTO topic)
        {
            Topic toDelete = Mapping.Mapper.Map<Topic>(topic);

            context.Database.Log = Console.WriteLine;
            context.Entry(toDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void DeleteTopic(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var topic = context.Topics.Find(ID);
            context.Topics.Remove(topic);
            context.SaveChanges();
        }

        public TopicDTO GetTopicByID(int ID)
        {
            context.Database.Log = Console.WriteLine;
            var topic = new Topic();
            foreach(var item in context.Topics.Include(x => x.Questions).ToList())
            {
                if (item.TopicID == ID)
                {
                    topic = item;
                }
            }

            //var topic = context.Topics.Find(ID);
            return Mapping.Mapper.Map<TopicDTO>(topic);
        }

        public List<TopicDTO> GetAllTopics()
        {
            var topics = new List<TopicDTO>();
            foreach (var item in context.Topics.Include(x => x.Questions).ToList())
            {
                topics.Add(Mapping.Mapper.Map<TopicDTO>(item));
            }
            return topics;
        }
    }
}
