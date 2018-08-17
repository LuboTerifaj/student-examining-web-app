using BL.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class QuestionController : Controller
    {

        private readonly QuestionFacade questionFacade;
        private readonly TopicFacade topicFacade;
        private readonly AnswerFacade answerFacade;

        public QuestionController(QuestionFacade questionFacade, TopicFacade topicFacade, AnswerFacade answerFacade)
        {
            this.questionFacade = questionFacade;
            this.topicFacade = topicFacade;
            this.answerFacade = answerFacade;
        }

        // GET: Question
        public ActionResult Index()
        {
            var questionViewModel = new QuestionViewModel()
            {
                Questions = questionFacade.GetAllQuestions()
            };
            return View(questionViewModel);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            var questionDetailModel = new QuestionDetailModel()
            {
                Question = questionFacade.GetQuestionByID(id)
            };
            return View(questionDetailModel);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            var questionEditModel = new QuestionEditModel()
            {
                Topics = topicFacade.GetAllTopics()
            };
            return View(questionEditModel);
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(QuestionEditModel model)
        {
            try
            {
                // TODO: Add insert logic here
                int questionID = questionFacade.CreateQuestion(model.Question, model.SelectedTopic);
                return RedirectToAction("CreateAnswer", new { questionID = questionID});
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            var questionEditModel = new QuestionEditModel()
            {
                Question = questionFacade.GetQuestionByID(id),
                Topics = topicFacade.GetAllTopics()
                
            };

            return View(questionEditModel);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(QuestionEditModel model)
        {
            try
            {
                questionFacade.EditQuestion(model.Question,model.SelectedTopic);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            questionFacade.DeleteQuestion(id);
            return RedirectToAction("Index");
        }
        /*
        // POST: Question/Delete/5
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

        // GET: Answer/Create
        public ActionResult CreateAnswer(int questionID)
        {
            var answerEditModel = new AnswerEditModel()
            {
                QuestionID = questionID
            };           
            return View(answerEditModel);
        }

        // POST: Answer/Create
        [HttpPost]
        public ActionResult CreateAnswer(AnswerEditModel model)
        {
            try
            {
                answerFacade.CreateAnswer(model.Answer, model.QuestionID);
                return RedirectToAction("Edit", new { id = model.QuestionID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult DeleteAnswer(int id)
        {
            var answer = answerFacade.GetAnswerByID(id);
            int questionID = answer.Question.QuestionID;

            answerFacade.DeleteAnswer(id);
            return RedirectToAction("Edit", new { questionID = questionID });
        }
    }
}
