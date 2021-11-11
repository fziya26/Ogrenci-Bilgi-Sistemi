using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOGRENCİ.Models.EntityFramework;

namespace MVCOGRENCİ.Controllers
{
    public class KuluplerController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Kulupler
        public ActionResult Index()
        {
            var kulupler = db.kulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(kulupler param)
        {
            db.kulupler.Add(param);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.kulupler.Find(id);
            db.kulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupDetayGetir(int id)
        {
            var kulup = db.kulupler.Find(id);
            return View("KulupDetayGetir", kulup);
        }
        public ActionResult Guncelle(kulupler param)
        {
            var kulup = db.kulupler.Find(param.kulup_id);
            kulup.kulup_adi = param.kulup_adi;
            kulup.kulup_kontenjan = param.kulup_kontenjan;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}