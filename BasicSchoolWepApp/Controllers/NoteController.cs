using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicSchoolWepApp.Models.EntityFramework;
using WebGrease.Css.Ast.Selectors;

namespace BasicSchoolWepApp.Controllers
{
    public class NoteController : Controller
    {
        // GET: Note
        private BasicSchoolDbEntities db = new BasicSchoolDbEntities();
        public ActionResult Index()
        {
            var notes = db.tbl_Notlar.ToList();
            return View(notes);
        }

        [HttpGet]
        public ActionResult AddNote()
        {
            List<SelectListItem> studentList = (from i in db.tbl_Ogrenciler.ToList()
                select new SelectListItem()
                {
                    Text = i.OgrAd + " " + i.OgrSoyad,
                    Value = i.OgrID.ToString()
                }
                ).ToList();
            List<SelectListItem> lessonList = (from i in db.tbl_Dersler.ToList()
                    select new SelectListItem()
                    {
                        Text = i.DersAd,
                        Value = i.DersId.ToString()
                    }
                ).ToList();
            ViewBag.listOfLesson = lessonList;
            ViewBag.listOfStudent = studentList;
            return View();
        }

        [HttpPost]
        public ActionResult AddNote(tbl_Notlar note)
        {
            var std = db.tbl_Ogrenciler.Where(s => s.OgrID == note.tbl_Ogrenciler.OgrID).SingleOrDefault();
            note.tbl_Ogrenciler = std;
            var lssn = db.tbl_Dersler.Where(l => l.DersId == note.tbl_Dersler.DersId).SingleOrDefault();
            note.tbl_Dersler = lssn;
            decimal averageNote = (Decimal.Parse(note.Sinav1.ToString()) + Decimal.Parse(note.Sinav2.ToString()) + Decimal.Parse(note.Sinav3.ToString()) + Decimal.Parse(note.Proje.ToString())) / 4;
            note.Ortalama = averageNote;
            bool stateNote;
            if (averageNote >= 55)
            {
                stateNote=true;
            }
            else
            {
                stateNote = false;
            }

            note.Durum = stateNote;
            var isNote = db.tbl_Notlar
                .Where(n => n.OgrId == note.tbl_Ogrenciler.OgrID & n.DersId == note.tbl_Dersler.DersId).ToList().Count;
            if (isNote == 0)
            {
                db.tbl_Notlar.Add(note);
                db.SaveChanges();
            }
            else
            {
                //var updateNote = db.Entry(note);
                //updateNote.State = EntityState.Modified;
                //db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateNote(int id)
        {
            List<SelectListItem> lessonsList = (from i in db.tbl_Dersler.ToList()
                    select new SelectListItem()
                    {
                        Text = i.DersAd,
                        Value = i.DersId.ToString()
                    }
                ).ToList();
            ViewBag.Lessons = lessonsList;
            List<SelectListItem> studentsList = (from i in db.tbl_Ogrenciler.ToList()
                    select new SelectListItem()
                    {
                        Text = i.OgrAd + " " + i.OgrSoyad,
                        Value = i.OgrID.ToString()
                    }
                ).ToList();
            ViewBag.Students = studentsList;

            var note = db.tbl_Notlar.Find(id);
            return View("UpdateNote", note);
        }
    }
}