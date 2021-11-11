using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOGRENCİ.Models.EntityFramework;
using MVCOGRENCİ.Models;

namespace MVCOGRENCİ.Controllers
{
    public class NotlarController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Notlar
        public ActionResult Index()
        {
            var notlar = db.notlar.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(notlar param)
        {
            db.notlar.Add(param);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var not = db.notlar.Find(id);
            db.notlar.Remove(not);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotDetayGetir(int id)
        {
            var not = db.notlar.Find(id);
            return View("NotDetayGetir", not);
        }
        [HttpPost]
        public ActionResult NotDetayGetir(Islem islemturu, notlar param, int sinav1_notu = 0, int sinav2_notu = 0, int sinav3_notu = 0, int proje_notu = 0)
        {
            float ortalama = (sinav1_notu + sinav2_notu + sinav3_notu + proje_notu) / 4;
            if (islemturu.islem == "HESAPLA")
            {
                ViewBag.ortalama = ortalama;
            }
            if (islemturu.islem == "GUNCELLE")
            {
                var not = db.notlar.Find(param.not_id);
                not.ders_id = param.ders_id;
                not.ogrenci_id = param.ogrenci_id;
                not.sinav1_notu = param.sinav1_notu;
                not.sinav2_notu = param.sinav2_notu;
                not.sinav3_notu = param.sinav3_notu;
                not.proje_notu = param.proje_notu;
                not.ortalama = param.ortalama;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }
    }

}