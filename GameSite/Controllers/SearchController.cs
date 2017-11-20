using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameSite.Models;

namespace GameSite.Controllers
{
    public class SearchController : Controller
    {
        private GameSiteContext db = new GameSiteContext();
        // GET: Search
        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Name", Value = "0" });

            items.Add(new SelectListItem { Text = "Genre", Value = "1" });

            items.Add(new SelectListItem { Text = "Pcode", Value = "2", Selected = true });
            ViewBag.source = items;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult results(string SearchValue, string source)
        {
            if (source == "0")
            {
                var results = (from a in db.Products where (a.Name.Contains(SearchValue)) select a).ToList();

                return View(results);
            }
             else if (source == "1")
            {
                var results = (from a in db.Products where (a.Genre.Contains(SearchValue)) select a).ToList();

                return View(results);
            }
            else if (source == "2")
            {
                var results = (from a in db.Products where (a.Pcode.Contains(SearchValue)) select a).ToList();

                return View(results);
            }
            else
            {
                return View();
            }
            //var results = (from a in db.Products where (a.Name.Contains(SearchValue)) select a).ToList();

            //return View(results);
        }
        [HttpGet]
        public ActionResult Pdetails(int? id)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }
    }
}