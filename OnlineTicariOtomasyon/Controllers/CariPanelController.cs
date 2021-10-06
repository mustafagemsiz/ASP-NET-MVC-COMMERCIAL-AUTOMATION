using OnlineTicariOtomasyon.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var deger = context.Caris.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.degerMail = mail;
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
    }
}