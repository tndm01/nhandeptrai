using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NNShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Không thể gọi trực tiếp.
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        //Không thể gọi trực tiếp.
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        //Không thể gọi trực tiếp.
        [ChildActionOnly]
        public ActionResult Category()
        {
            return PartialView();
        }
    }
}