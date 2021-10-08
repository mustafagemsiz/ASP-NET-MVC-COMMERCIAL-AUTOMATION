using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;
namespace OnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {

        DataContext context = new DataContext();
        // GET: Personel
        public ActionResult Index()
        {
            var deger = context.Personels.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.departmanAd = new SelectList(context.Departmans, "DepartmanId", "DepartmanAd");
            return View();
        }

        [HttpPost]
       
        public ActionResult Create(Personel p)
        {
            ViewBag.departmanAd = new SelectList(context.Departmans, "DepartmanId", "DepartmanAd");

            //if (Request.Files.Count>0)
            //{
            //    string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
            //    string uzanti = Path.GetExtension(Request.Files[0].FileName);
            //    string yol = "/Image/" + dosyaAdi ;
            //    Request.Files[0].SaveAs(Server.MapPath(yol));
            //    p.PersonelGorsel = "/Image/" + dosyaAdi;
            //}

            if (Request.Files.Count > 0)
            {
                var extention = Path.GetExtension(Request.Files[0].FileName);
                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");
                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");
                p.PersonelGorsel = "/Images/" + randomName;
                var path = "~/Images/" + randomName;
                Request.Files[0].SaveAs(Server.MapPath(path));
            }

            if (ModelState.IsValid)
            {
                context.Personels.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.departmanAd = new SelectList(context.Departmans, "DepartmanId", "DepartmanAd");

            var deger = context.Personels.Find(id);
            return View(deger);
        }

        [HttpPost]
        public ActionResult Edit(Personel p)
        {
            ViewBag.departmanAd = new SelectList(context.Departmans, "DepartmanId", "DepartmanAd");

            if (Request.Files.Count > 0)
            {
                var extention = Path.GetExtension(Request.Files[0].FileName);
                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");
                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");
                p.PersonelGorsel = "/Images/" + randomName;
                var path = "~/Images/" + randomName;
                Request.Files[0].SaveAs(Server.MapPath(path));
            }

            if (ModelState.IsValid)
            {
                var deger = context.Personels.Find(p.PersonelId);
                deger.PersonelAd = p.PersonelAd;
                deger.PersonelSoyad = p.PersonelSoyad;
                deger.PersonelAdres = p.PersonelAdres;
                deger.PersonelGorsel = p.PersonelGorsel;
                deger.PersonelTelefon = p.PersonelTelefon;
                deger.DepartmanId = p.DepartmanId;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult List()
        {
            var deger = context.Personels.ToList();
            return View(deger);
        }
    }
}