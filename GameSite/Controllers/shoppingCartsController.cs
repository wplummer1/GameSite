using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameSite.Models;

namespace GameSite.App_Start
{
    public class shoppingCartsController : Controller
    {
        private GameSiteContext db = new GameSiteContext();

        // GET: shoppingCarts
        public ActionResult Index()
        {
            return View(db.shoppingCarts.ToList());
        }

        // GET: shoppingCarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shoppingCart shoppingCart = db.shoppingCarts.Find(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // Add to Cart Function
        public ActionResult AddToCart(string gameName)
        {
            var temp = (from s in db.Products
                        where s.Name == gameName
                        select s
                        );
            var temp2 = new shoppingCart { };

            var result = temp.FirstOrDefault();

            if (result != null)
            {
                //temp2.ID = result.ID;
                temp2.UName = "Nama Jeff"; //This is a placeholder
                temp2.Pname = result.Name;
                temp2.quantity = "1";
                temp2.addedDate = DateTime.Now;

                db.shoppingCarts.Add(temp2);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: shoppingCarts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: shoppingCarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UName,Pname,quantity,addedDate")] shoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                db.shoppingCarts.Add(shoppingCart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingCart);
        }

        // GET: shoppingCarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shoppingCart shoppingCart = db.shoppingCarts.Find(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // POST: shoppingCarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UName,Pname,quantity,addedDate")] shoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingCart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingCart);
        }

        // GET: shoppingCarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shoppingCart shoppingCart = db.shoppingCarts.Find(id);
            if (shoppingCart == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCart);
        }

        // POST: shoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            shoppingCart shoppingCart = db.shoppingCarts.Find(id);
            db.shoppingCarts.Remove(shoppingCart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
