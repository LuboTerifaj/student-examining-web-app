using BL.DTO;
using BL.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        private readonly TestFacade testFacade;
        private readonly TopicFacade topicFacade;
        private readonly StudentGroupFacade studentGroupFacade;
        private readonly TestResultFacade testResultFacade;

        public TestController(TestFacade testFacade, TopicFacade topicFacade, 
                                StudentGroupFacade studentGroupFacade, TestResultFacade testResultFacade)
        {
            this.testFacade = testFacade;
            this.topicFacade = topicFacade;
            this.studentGroupFacade = studentGroupFacade;
            this.testResultFacade = testResultFacade;
        }

        // GET: Test
        public ActionResult Index()
        {
            var testViewModel = new TestViewModel()
            {
                Tests = testFacade.GetAllTests()
            };

            return View(testViewModel);
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            var testDetailModel = new TestDetailModel()
            {
                Test = testFacade.GetTestByID(id)
            };
            return View(testDetailModel);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            var testEditModel = new TestEditModel()
            {
                Topics = topicFacade.GetAllTopics(),
                StudentGroups = studentGroupFacade.GetAllStudentGroups()
            };

            return View(testEditModel);
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(TestEditModel testEditModel)
        {
            try
            {
                testFacade.CreateTest(testEditModel.Test, testEditModel.SelectedTopics, 
                                      testEditModel.SelectedStudentGroups, testEditModel.NumberOfQuestions);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(testEditModel);
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            var testEditModel = new TestEditModel()
            {
                Test = testFacade.GetTestByID(id)
            };
            return View(testEditModel);
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(TestEditModel testEditModel)
        {
            try
            {
                testFacade.EditTest(testEditModel.Test);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            testFacade.DeleteTest(id);
            return RedirectToAction("Index");
        }
        /*
        // POST: Test/Delete/5
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

        public ActionResult TestRun(int id)
        {
            TestDTO test = testFacade.GetTestByID(id);
            if (test.TimeFrom <= DateTime.Now && test.TimeTo >= DateTime.Now)
            {
                var testRunModel = new TestRunModel()
                {
                    Test = testFacade.GetTestByID(id)
                };
                foreach (var item in testRunModel.Test.Questions)
                {
                    foreach (var answer in item.Answers)
                    {
                        testRunModel.MarkedAnswers.Add(answer.AnswerID, false);
                    }
                }
                testRunModel.TestResult.OpenedTime = DateTime.Now;
                testRunModel.TestResult.Test = testRunModel.Test;

                return View(testRunModel);
            }
            return View("TestCannotRun");            
        }

        [HttpPost]
        public ActionResult TestRun(TestRunModel testRunModel)
        {
            try
            {
                testRunModel.TestResult.SavedTime = DateTime.Now;                                
                int id = testResultFacade.CreateTestResult(testRunModel.TestResult, testRunModel.MarkedAnswers);
                
                var testResultViewModel = new TestResultViewModel()
                {
                    TestResult = testResultFacade.getTestResultByID(id)
                };
                return RedirectToAction("TestResultView", testResultViewModel);
                //return View("TestRunView",testRunModel);                
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult TestResultView(TestResultViewModel testResultViewModel)
        {
            return View(testResultViewModel);
        }
        
    }
}
