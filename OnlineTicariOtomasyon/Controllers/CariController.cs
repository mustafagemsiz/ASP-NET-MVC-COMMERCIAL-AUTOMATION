using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;
namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        DataContext context = new DataContext();

        // GET: Cari
        [HttpGet]
        public ActionResult Index()
        {
            var deger = context.Caris.Where(x=>x.Durum==true).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cari c)
        {
            if (ModelState.IsValid)
            {
                context.Caris.Add(c);
                c.Durum = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var deger = context.Caris.Find(id);
                deger.Durum = false;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var deger = context.Caris.Find(id);
            return View("Edit", deger);
        }

        [HttpPost]
        public ActionResult Edit(Cari c)
        {
            if (ModelState.IsValid)
            {
                var deger = context.Caris.Find(c.CariId);
                deger.CariAd = c.CariAd;
                deger.CariSoyad = c.CariSoyad;
                deger.CariSehir = c.CariSehir;
                deger.CariMail = c.CariMail;
                deger.Durum = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        [HttpGet]
        public ActionResult CustomerDetail(int id)
        {
            var deger = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(deger);
        }
    }
}