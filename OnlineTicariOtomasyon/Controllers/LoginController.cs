using OnlineTicariOtomasyon.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        DataContext context = new DataContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult CreateUserPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult CreateUserPartial(Cari p)
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(Cari p)
        {
            var deger = context.Caris.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (deger!=null)
            {
                FormsAuthentication.SetAuthCookie(deger.CariMail, false);
                Session["CariMail"] = deger.CariMail.ToString();

                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
            return RedirectToAction("Index","Login");

            }
        }
    }
}