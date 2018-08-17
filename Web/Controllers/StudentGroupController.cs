using BL.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class StudentGroupController : Controller
    {

        private readonly StudentGroupFacade studentGroupFacade;

        public StudentGroupController(StudentGroupFacade studentGroupFacade)
        {
            this.studentGroupFacade = studentGroupFacade;
        }
        
        // GET: StudentGroup
        public ActionResult Index()
        {
            var studentGroupViewModel = new StudentGroupViewModel()
            {
                StudentGroups = studentGroupFacade.GetAllStudentGroups()
            };
            return View(studentGroupViewModel);
        }

        // GET: StudentGroup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentGroup/Create
        public ActionResult Create()
        {
            var studentGroupEditModel = new StudentGroupEditModel();
            
            return View(studentGroupEditModel);
        }

        // POST: StudentGroup/Create
        [HttpPost]
        public ActionResult Create(StudentGroupEditModel model)
        {
            try
            {
                // TODO: Add insert logic here
                studentGroupFacade.CreateStudentGroup(model.StudentGroup);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGroup/Edit/5
        public ActionResult Edit(int id)
        {
            var studentGroupEditModel = new StudentGroupEditModel()
            {
                StudentGroup = studentGroupFacade.GetStudentGroupByID(id)
            };

            return View(studentGroupEditModel);
        }

        // POST: StudentGroup/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentGroupEditModel model)
        {
            try
            {
                // TODO: Add update logic here
                studentGroupFacade.EditStudentGroup(model.StudentGroup);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGroup/Delete/5
        public ActionResult Delete(int id)
        {
            studentGroupFacade.DeleteStudentGroup(id);
            return RedirectToAction("Index");
        }
        /*
        // POST: StudentGroup/Delete/5
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
