using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        DataContext context = new DataContext();
        // GET: UrunDetay
        public ActionResult Index()
        {
            var deger = context.Uruns.Where(x=>x.UrunId==1).ToList();
            return View(deger);
        }
    }
}