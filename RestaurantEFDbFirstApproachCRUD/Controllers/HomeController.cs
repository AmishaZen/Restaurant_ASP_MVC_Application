using RestaurantEFDbFirstApproachCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantEFDbFirstApproachCRUD.Controllers
{
    public class HomeController : Controller
    {
        WFA3DotNetEntities db = new WFA3DotNetEntities();
        public ActionResult Index(string search="")
        {
            //ViewBag.Search = 
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
    }
}