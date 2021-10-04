using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;
namespace OnlineTicariOtomasyon.Controllers
{
    public class ToDoController : Controller
    {
        DataContext context = new DataContext();
        // GET: ToDo
        public ActionResult Index()
        {
            var degerCari = context.Caris.Count().ToString();
            ViewBag.Cari = degerCari;

            var degerUrun = context.Uruns.Count().ToString();
            ViewBag.Urun = degerUrun;

            var degerKategori = context.Kategoris.Count().ToString();
            ViewBag.Kategori = degerKategori;

            var degerSehir = (from x in context.Caris select x.CariSehir).Distinct().Count().ToString();
            ViewBag.Sehir = degerSehir;

            var ToDo = context.ToDos.ToList();
            return View(ToDo);
        }
    }
}