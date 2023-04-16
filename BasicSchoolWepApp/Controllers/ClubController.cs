using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicSchoolWepApp.Models.EntityFramework;

namespace BasicSchoolWepApp.Controllers
{
    public class ClubController : Controller
    {
        // GET: Club
        BasicSchoolDbEntities db = new BasicSchoolDbEntities();
        public ActionResult Index()
        {
            var clubs = db.tbl_Kulupler.ToList();
            return View(clubs);
        }

        [HttpGet]
        public ActionResult AddClub()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClub(tbl_Kulupler clb)
        {
            db.tbl_Kulupler.Add(clb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClub(int id)
        {
            var club = db.tbl_Kulupler.Find(id);
            db.tbl_Kulupler.Remove(club);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult DeleteClub(int id)
        //{
        //    var deletedClub = db.tbl_Kulupler.Find(id);
        //    return View(deletedClub);
        //}

        //[HttpPost]
        //public ActionResult DeleteClub(tbl_Kulupler deletedClub)
        //{
        //    var club = deletedClub;
        //    db.tbl_Kulupler.Remove(club);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult UpdateClub(int id)
        {
            var club = db.tbl_Kulupler.Find(id);
            return View("UpdateClub", club);
        }

        [HttpPost]
        public ActionResult UpdateClub(tbl_Kulupler clb)
        {
            var club = db.tbl_Kulupler.Find(clb.KulupId);
            club.KulupAd = clb.KulupAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}