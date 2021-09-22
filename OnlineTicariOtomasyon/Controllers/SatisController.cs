using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        DataContext context = new DataContext();
        // GET: Satis
        public ActionResult Index()
        {
            var deger = context.SatisHarekets.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.urunAd = new SelectList(context.Uruns, "UrunId", "UrunAd");

            var cari = context.Caris
         .Select(x =>
                 new
                 {
                     id = x.CariId,
                     nameSurname = x.CariAd + " " + x.CariSoyad
                 });

            ViewBag.cariAdSoyad = new SelectList(cari, "id", "nameSurname");

            var personel = context.Personels.Where(x => x.DepartmanId == 2)
                     .Select(x =>
                             new
                             {
                                 id = x.PersonelId,
                                 nameSurname = x.PersonelAd + " " + x.PersonelSoyad
                             });

            ViewBag.personelAdSoyad = new SelectList(personel, "id", "nameSurname");
            //ViewBag.personelAdSoyad = new SelectList(context.Personels, "PersonelId", "PersonelAd", "PersonelSoyad");

            return View();
        }

        [HttpPost]
        public ActionResult Create(SatisHareket s)
        {
            ViewBag.urunAd = new SelectList(context.Uruns, "UrunId", "UrunAd");

            var cari = context.Caris
         .Select(x =>
                 new
                 {
                     id = x.CariId,
                     nameSurname = x.CariAd + " " + x.CariSoyad
                 });

            ViewBag.cariAdSoyad = new SelectList(cari, "id", "nameSurname");

            var personel = context.Personels.Where(x => x.DepartmanId == 2)
                     .Select(x =>
                             new
                             {
                                 id = x.PersonelId,
                                 nameSurname = x.PersonelAd + " " + x.PersonelSoyad
                             });

            ViewBag.personelAdSoyad = new SelectList(personel, "id", "nameSurname");

            if (ModelState.IsValid)
            {
                context.SatisHarekets.Add(s);
                s.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);

        }
    }
}