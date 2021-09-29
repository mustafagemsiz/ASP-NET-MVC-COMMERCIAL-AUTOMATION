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
        UrunListele urunListele = new UrunListele();
        // GET: UrunDetay
        public ActionResult Index()
        {
            //var deger = context.Uruns.Where(x=>x.UrunId==1).ToList();

            urunListele.Deger1 = context.Uruns.Where(x => x.UrunId == 1).ToList();
            urunListele.Deger2 = context.UrunDetays.Where(x => x.DetayId == 1).ToList();
            return View(urunListele);
        }
    }
}