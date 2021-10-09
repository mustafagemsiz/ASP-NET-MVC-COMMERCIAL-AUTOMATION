using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        DataContext context = new DataContext();
        // GET: Urun
        public ActionResult Index()
        {
            var deger = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //List<SelectListItem> kategori = (from x in context.Kategoris.ToList()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = x.KategoriAd,
            //                                     Value = x.KategoriId.ToString()
            //                                 }
            //                                 ).ToList();
            //ViewBag.kategoriAd = kategori;
            ViewBag.kategoriAd = new SelectList(context.Kategoris, "KategoriId", "KategoriAd");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Urun u)
        {
            ViewBag.kategoriAd = new SelectList(context.Kategoris, "KategoriId", "KategoriAd");
            if (ModelState.IsValid)
            {
                context.Uruns.Add(u);
                u.Durum = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var deger = context.Uruns.Find(id);
                deger.Durum = false;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }


        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //List<SelectListItem> kategori = (from x in context.Kategoris.ToList()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = x.KategoriAd,
            //                                     Value = x.KategoriId.ToString()
            //                                 }
            //                     ).ToList();
            //ViewBag.kategoriAd = kategori;
            ViewBag.kategoriAd = new SelectList(context.Kategoris, "KategoriId", "KategoriAd");

            var deger = context.Uruns.Find(id);
            return View("Edit", deger);
        }

        [HttpPost]
        public ActionResult Edit(Urun p)
        {
            ViewBag.kategoriAd = new SelectList(context.Kategoris, "KategoriId", "KategoriAd");
            if (ModelState.IsValid)
            {
                var deger = context.Uruns.Find(p.UrunId);
                deger.AlisFiyat = p.AlisFiyat;
                deger.SatisFiyat = p.SatisFiyat;
                deger.Durum = p.Durum;
                deger.Marka = p.Marka;
                deger.UrunAd = p.UrunAd;
                deger.Durum = true;
                deger.Stok = p.Stok;
                deger.KategoriId = p.KategoriId;
                deger.UrunGorsel = p.UrunGorsel;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Sell(int id)
        {
            var urunId = context.Uruns.Find(id);
            ViewBag.urunAd = urunId.UrunId;

            var urunFiyat = context.Uruns.Find(id);
            ViewBag.urunSatisFiyat = urunFiyat.SatisFiyat;
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

            ViewBag.personelAdSoyad = new SelectList(personel, "id", "nameSurname"); return View();
        }

        [HttpPost]
        public ActionResult Sell(SatisHareket p)
        {

            var cari = context.Caris.Select(x =>
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

            context.SatisHarekets.Add(p);
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SaveChanges();
            return RedirectToAction("Index","Satis");
        }

    }
}