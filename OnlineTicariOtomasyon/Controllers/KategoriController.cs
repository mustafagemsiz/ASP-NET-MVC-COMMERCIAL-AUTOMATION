using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        DataContext context = new DataContext();
        [HttpGet]
        public ActionResult Index()
        {
            var deger = context.Kategoris.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kategori k)
        {
            if (ModelState.IsValid)
            {
                context.Kategoris.Add(k);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(k);
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
                var deger = context.Kategoris.Find(id);
                context.Kategoris.Remove(deger);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var deger = context.Kategoris.Find(id);
            return View("Edit", deger);
        }

        [HttpPost]
        public ActionResult Edit(Kategori k)
        {
            if (ModelState.IsValid)
            {
                var deger = context.Kategoris.Find(k.KategoriId);
                deger.KategoriAd = k.KategoriAd;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(k);
        }
    }
}