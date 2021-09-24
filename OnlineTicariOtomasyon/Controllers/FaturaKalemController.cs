using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;


namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturaKalemController : Controller
    {
        DataContext context = new DataContext();

        // GET: FaturaKalem
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FaturaKalem f)
        {

            if (ModelState.IsValid)
            {
                var deger = context.FaturaKalems.Add(f);
                context.SaveChanges();
                return RedirectToAction("Index", "Fatura");
            }
            return View(f);

        }
    }
}