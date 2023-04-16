using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BasicSchoolWepApp.Models.EntityFramework;

namespace BasicSchoolWepApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private BasicSchoolDbEntities db = new BasicSchoolDbEntities();
        public ActionResult Index()
        {
            var students = db.tbl_Ogrenciler.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            List<SelectListItem> clubList = (from i in db.tbl_Kulupler.ToList()
                    select new SelectListItem()
                    {
                        Text = i.KulupAd,
                        Value = i.KulupId.ToString()
                    }
                ).ToList();
            ViewBag.listClub = clubList;
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(tbl_Ogrenciler student)
        {
            var klp = db.tbl_Kulupler.Where(c => c.KulupId == student.tbl_Kulupler.KulupId).SingleOrDefault();
            student.tbl_Kulupler = klp;
            db.tbl_Ogrenciler.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            var student = db.tbl_Ogrenciler.Find(id);
            db.tbl_Ogrenciler.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            List<SelectListItem> clubList = (from i in db.tbl_Kulupler.ToList()
                    select new SelectListItem
                    {
                        Value = i.KulupId.ToString(),
                        Text = i.KulupAd
                    }
                ).ToList();
            ViewBag.listClub = clubList;
            var student = db.tbl_Ogrenciler.Find(id);
            return View("UpdateStudent", student);
        }

        [HttpPost]
        public ActionResult UpdateStudent(tbl_Ogrenciler std)
        {
            

            var student = db.tbl_Ogrenciler.Find(std.OgrID);
            var klp = db.tbl_Kulupler.Where(c => c.KulupId == std.tbl_Kulupler.KulupId).SingleOrDefault();
            std.tbl_Kulupler = klp;

            student.OgrAd = std.OgrAd;
            student.OgrSoyad = std.OgrSoyad;
            student.OgrID = std.OgrID;
            student.OgrCinsiyet = std.OgrCinsiyet;
            student.OgrTelefon = std.OgrTelefon;
            student.OgrMail = std.OgrMail;
            student.OgrFotograf = std.OgrFotograf;
            student.OgrSifre = std.OgrSifre;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}