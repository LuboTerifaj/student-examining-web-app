using BL.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly TopicFacade topicFacade;

        public TopicController(TopicFacade topicFacade)
        {
            this.topicFacade = topicFacade;
        }

        // GET: Topic
        public ActionResult Index()
        {
            var topicViewModel = new TopicViewModel()
            {
                Topics = topicFacade.GetAllTopics()
            };
            return View(topicViewModel);
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            var topicDetailModel = new TopicDetailModel()
            {
                Topic = topicFacade.GetTopicByID(id)
            };
            return View(topicDetailModel);
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            var topicEditModel = new TopicEditModel()
            {
                Topics = topicFacade.GetAllTopics()
            };
            return View(topicEditModel);
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(TopicEditModel model)
        {
            try
            {
                topicFacade.CreateTopic(model.Topic, model.SelectedParent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(int id)
        {
            var topicEditModel = new TopicEditModel()
            {
                Topic = topicFacade.GetTopicByID(id),
                Topics = topicFacade.GetAllTopics()
            };
            return View(topicEditModel);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        public ActionResult Edit(TopicEditModel model)
        {
            try
            {
                topicFacade.EditTopic(model.Topic, model.SelectedParent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Delete/5
        public ActionResult Delete(int ID)
        {
            topicFacade.DeleteTopic(ID);
            return RedirectToAction("Index");            
        }
        /*
        // POST: Topic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
