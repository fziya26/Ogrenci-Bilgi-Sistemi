using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOGRENCİ.Models.EntityFramework;

namespace MVCOGRENCİ.Controllers
{
    public class OgrenciController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogrenciler = db.ogrenciler.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> kulupler = (from i in db.kulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kulup_adi,
                                                 Value = i.kulup_id.ToString()
                                             }
                                             ).ToList();
            ViewBag.kulupler = kulupler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(ogrenciler param)
        {
            var kulup = db.kulupler.Where(m =>m.kulup_id == param.kulupler.kulup_id).FirstOrDefault();
            param.kulupler = kulup;
            db.ogrenciler.Add(param);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.ogrenciler.Find(id);
            db.ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult OgrenciDetayGetir(int id)
        {
            var ogrenci = db.ogrenciler.Find(id);
            List<SelectListItem> kulupler = (from i in db.kulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kulup_adi,
                                                 Value = i.kulup_id.ToString()
                                             }
                                             ).ToList();
            ViewBag.kulupler = kulupler;
            return View("OgrenciDetayGetir", ogrenci);
        }
        public ActionResult Guncelle(ogrenciler param)
        {
            var ogrenci = db.ogrenciler.Find(param.ogrenci_id);
            ogrenci.ad = param.ad;
            ogrenci.soyad = param.soyad;
            ogrenci.foto = param.foto;
            ogrenci.kulup = param.kulupler.kulup_id;
            ogrenci.cinsiyet = param.cinsiyet;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}