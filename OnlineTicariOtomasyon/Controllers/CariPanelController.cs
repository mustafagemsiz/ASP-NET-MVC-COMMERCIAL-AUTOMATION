using OnlineTicariOtomasyon.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        DataContext context = new DataContext();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var deger = context.Caris.Where(x => x.CariMail == mail).ToList();
            ViewBag.degerMail = mail;
            var mailId = context.Caris.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();

            var toplamSatis = context.SatisHarekets.Where(y => y.CariId == mailId).Count();
            ViewBag.ToplamSatis = toplamSatis.ToString();

            var urun = context.SatisHarekets.Where(x => x.CariId == mailId).Sum(y => y.Adet);
            ViewBag.UrunAdet = urun;

            var tutar = context.SatisHarekets.Where(x => x.CariId == mailId).Sum(y => y.ToplamTutar);
            ViewBag.Tutar = tutar;

            return View(deger);
        }

        [HttpGet]
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CariMail"];
            var id = context.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var deger = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult Message()
        {
            var mail = (string)Session["CariMail"];

            var deger = context.Mesajs.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajId).ToList();
            ViewBag.gelenMesaj = context.Mesajs.Where(x => x.Alici == mail).Count();
            if (ViewBag.gelenMesaj == null)
            {
                ViewBag.gelenMesaj = 0;
            }

            var deger2 = context.Mesajs.Where(x => x.Gonderici == mail).ToList();

            ViewBag.gidenMesaj = context.Mesajs.Where(x => x.Gonderici == mail).Count();
            if (ViewBag.gidenMesaj == null)
            {
                ViewBag.gidenMesaj = 0;
            }
            return View(deger);
        }

        [HttpGet]
        public ActionResult MessageGet()
        {
            var mail = (string)Session["CariMail"];
            var deger = context.Mesajs.Where(x => x.Gonderici == mail).OrderByDescending(x => x.MesajId).ToList();

            ViewBag.gelenMesaj = context.Mesajs.Where(x => x.Alici == mail).Count();
            if (ViewBag.gelenMesaj == null)
            {
                ViewBag.gelenMesaj = 0;
            }

            var deger2 = context.Mesajs.Where(x => x.Gonderici == mail).ToList();

            ViewBag.gidenMesaj = context.Mesajs.Where(x => x.Gonderici == mail).Count();
            if (ViewBag.gidenMesaj == null)
            {
                ViewBag.gidenMesaj = 0;
            }

            return View(deger);
        }

        [HttpGet]
        public ActionResult MessageDetail(int id)
        {
            var deger = context.Mesajs.Where(x => x.MesajId == id).ToList();


            var mail = (string)Session["CariMail"];

            ViewBag.gelenMesaj = context.Mesajs.Where(x => x.Alici == mail).Count();

            if (ViewBag.gelenMesaj == null)
            {
                ViewBag.gelenMesaj = 0;
            }

            ViewBag.gidenMesaj = context.Mesajs.Where(x => x.Gonderici == mail).Count();
            if (ViewBag.gidenMesaj == null)
            {
                ViewBag.gidenMesaj = 0;
            }

            return View(deger);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CariMail"];

            ViewBag.gelenMesaj = context.Mesajs.Where(x => x.Alici == mail).Count();

            if (ViewBag.gelenMesaj == null)
            {
                ViewBag.gelenMesaj = 0;
            }

            ViewBag.gidenMesaj = context.Mesajs.Where(x => x.Gonderici == mail).Count();

            if (ViewBag.gidenMesaj == null)
            {
                ViewBag.gidenMesaj = 0;
            }
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Mesaj p)
        {
            var mail = (string)Session["CariMail"];

            ViewBag.gelenMesaj = context.Mesajs.Where(x => x.Alici == mail).Count();

            if (ViewBag.gelenMesaj == null)
            {
                ViewBag.gelenMesaj = 0;
            }

            ViewBag.gidenMesaj = context.Mesajs.Where(x => x.Gonderici == mail).Count();

            if (ViewBag.gidenMesaj == null)
            {
                ViewBag.gidenMesaj = 0;
            }

            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Gonderici = mail.ToString();
            var deger = context.Mesajs.Add(p);
            context.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult KargoTakip(string p)
        {
            var k = from x in context.KargoDetays select x;
            k = k.Where(y => y.TakipKodu.Contains(p));
            return View(k.ToList());
        }

        [HttpGet]
        public ActionResult KargoDetail(string id)
        {
            ViewBag.kargoTakip = id;
            var deger = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(deger);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }

}