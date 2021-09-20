using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;
namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        DataContext context = new DataContext();
            // GET: Departman
        public ActionResult Index()
        {
            var deger = context.Departmans.Where(x => x.Durum == true).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Departman d)
        {
            if (ModelState.IsValid)
            {
                context.Departmans.Add(d);
                d.Durum = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);
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
                var deger = context.Departmans.Find(id);
                deger.Durum = false;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var deger = context.Departmans.Find(id);
            return View("Edit",deger);
        }

        [HttpPost]
        public ActionResult Edit(Departman d)
        {
            if (ModelState.IsValid)
            {
                var deger = context.Departmans.Find(d.DepartmanId);
                deger.DepartmanAd = d.DepartmanAd;
                deger.Durum = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var deger = context.Personels.Where(x => x.DepartmanId == id).ToList();
            var departmanAd = context.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.ad = departmanAd;
            return View(deger);
        }

        [HttpGet]
        public ActionResult PersonalDetail(int id)
        {
            var deger = context.SatisHarekets.Where(x => x.PersonelId == id).ToList();

            return View(deger);
        }
    }
}