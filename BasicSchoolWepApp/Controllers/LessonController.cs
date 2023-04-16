using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicSchoolWepApp.Models.EntityFramework;

namespace BasicSchoolWepApp.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson

        BasicSchoolDbEntities db = new BasicSchoolDbEntities();
        public ActionResult Index()
        {
            var lessons = db.tbl_Dersler.ToList();
            return View(lessons);
        }

        [HttpGet]
        public ActionResult AddLesson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLesson(tbl_Dersler ders)
        {
            db.tbl_Dersler.Add(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteLesson(int id)
        {
            var lesson = db.tbl_Dersler.Find(id);
            db.tbl_Dersler.Remove(lesson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateLesson(int id)
        {
            var lesson = db.tbl_Dersler.Find(id);
            return View("UpdateLesson",lesson);
        }

        [HttpPost]
        public ActionResult UpdateLesson(tbl_Dersler lssn)
        {
            var lesson = db.tbl_Dersler.Find(lssn.DersId);
            lesson.DersAd = lssn.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}