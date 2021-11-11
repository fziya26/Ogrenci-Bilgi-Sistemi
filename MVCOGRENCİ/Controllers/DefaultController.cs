using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOGRENCİ.Models.EntityFramework;

namespace MVCOGRENCİ.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.dersler.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(dersler param)
        {
            db.dersler.Add(param);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ders = db.dersler.Find(id);
            db.dersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersDetayGetir(int id)
        {
            var ders = db.dersler.Find(id);
            return View("DersDetayGetir", ders);
        }
        public ActionResult Guncelle(dersler param)
        {
            var ders = db.dersler.Find(param.ders_id);
            ders.ders_adi = param.ders_adi;
            db.SaveChanges();
            return RedirectToAction("Index","Default");
        }
    }
}