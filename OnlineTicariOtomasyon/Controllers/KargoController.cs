using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;
namespace OnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        DataContext context = new DataContext();
        // GET: Kargo
        public ActionResult Index()
        {
            var deger = context.KargoDetays.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Create()
        {

            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "I", "J", "K", "L" ,"P","R","S","O"};
            int k1, k2, k3;
            k1 = rnd.Next(0, 13);
            k2 = rnd.Next(0, 13);
            k3 = rnd.Next(0, 13);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];
            ViewBag.takipKod = kod;
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(KargoDetay p)
        {

            if (ModelState.IsValid)
            {
                context.KargoDetays.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Detail(string id)
        {
         
            ViewBag.kargoTakip = id;
            var deger = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(deger);
        }
    }
}