using OnlineTicariOtomasyon.Models.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        DataContext context = new DataContext();
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[]
            { "Mobilya","Ofis Eşyaları","Bilgisayar"}, yValues: new[] { 85, 66, 98 }).Write();

            return File(grafikciz.ToWebImage().GetBytes(),"image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();
            var sonuclar = context.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xValues.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yValues.Add(y.Stok));
            var grafik = new Chart(800, 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "pie", name: "Stok", xValue: xValues, yValues: yValues);
            return File(grafik.ToWebImage().GetBytes(),"image/jpeg");
        }
    }
}