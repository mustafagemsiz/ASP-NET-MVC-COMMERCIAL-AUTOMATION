using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;

namespace OnlineTicariOtomasyon.Controllers

{
    public class FaturaController : Controller
    {
        DataContext context = new DataContext();
        // GET: Fatura
        public ActionResult Index()
        {
            var deger = context.Faturas.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Fatura f)
        {
            if (ModelState.IsValid)
            {
                var deger = context.Faturas.Add(f);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(f);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var deger = context.Faturas.Find(id);
            return View("Edit",deger);
        }

        [HttpPost]
        public ActionResult Edit(Fatura f)
        {
            if (ModelState.IsValid)
            {
                var deger = context.Faturas.Find(f.FaturaId);
                deger.FaturaSeriNo = f.FaturaSeriNo;
                deger.FaturaSıraNo = f.FaturaSıraNo;
                deger.Saat = f.Saat;
                deger.Tarih = f.Tarih;
                deger.TeslimAlan = f.TeslimAlan;
                deger.TeslimEden = f.TeslimEden;
                deger.VergiDairesi = f.VergiDairesi;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(f);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var deger = context.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            return View("Detail",deger);
        }
    }
}