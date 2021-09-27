using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;
namespace OnlineTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        DataContext context = new DataContext();
        public ActionResult Index()
        {
            var deger = context.Uruns.ToList();
            return View(deger);
        }
    }
}