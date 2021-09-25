using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Model;
namespace OnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        DataContext context = new DataContext();
        // GET: Istatistik
        public ActionResult Index()
        {
            return View();
        }
    }
}