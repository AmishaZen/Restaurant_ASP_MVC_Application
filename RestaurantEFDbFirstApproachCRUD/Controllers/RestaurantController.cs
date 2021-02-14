using RestaurantEFDbFirstApproachCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantEFDbFirstApproachCRUD.Controllers
{
    
    public class RestaurantController : Controller
    {
        WFA3DotNetEntities db = new WFA3DotNetEntities();
        // GET: Restaurant
        public ActionResult Index(string search="")
        {
            //var rest = db.Restaurants.ToList();
            var rest = db.Restaurants.Where(r => r.RestaurantName.Contains(search)).ToList();
            return View(rest);
        }

        //Show Restaurant Details
        public ActionResult ShowDetails(int id)
        {
            Restaurant details = db.Restaurants.Where(r=>r.RestaurantId==id).FirstOrDefault();
            return View(details);
        }

        //Create operation
        public ActionResult AddRecord()
        {
            ViewBag.Restau = db.Restaurants.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddRecord(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit 

        public ActionResult UpdateRecord(int id)
        {
            var restoUpdate = db.Restaurants.Where(r => r.RestaurantId == id).FirstOrDefault();

            return View(restoUpdate);
        }

        [HttpPost]
        public ActionResult UpdateRecord(Restaurant restaurant)
        {
            var restoUpdate = db.Restaurants.Where(r => r.RestaurantId == restaurant.RestaurantId).FirstOrDefault();
            restoUpdate.RestaurantName = restaurant.RestaurantName;
            restoUpdate.Cusine = restaurant.Cusine;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var delete = db.Restaurants.Where(r => r.RestaurantId == id).FirstOrDefault();
            return View(delete);
        }

        [HttpPost]
        public ActionResult Delete(Restaurant restaurant)
        {
            var delete = db.Restaurants.Where(r => r.RestaurantId == restaurant.RestaurantId).FirstOrDefault();
            db.Restaurants.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Image()
        {
            return View();
        }
    }
}