using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gotcha.Models;

namespace Gotcha.Controllers
{
    public class SpelersController : Controller
    {
        private GotchaData db = new GotchaData();

        // GET: Spelers
        public ActionResult Index()
        {
            return View(db.Spelers.ToList());
        }

        // GET: Spelers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speler speler = db.Spelers.Find(id);
            if (speler == null)
            {
                return HttpNotFound();
            }
            return View(speler);
        }

        // GET: Spelers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "playerID,accountType,firstName,lastName,alias,schoolClass,targetID")] Speler speler)
        {
            if (ModelState.IsValid)
            {
                db.Spelers.Add(speler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(speler);
        }

        // GET: Spelers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speler speler = db.Spelers.Find(id);
            if (speler == null)
            {
                return HttpNotFound();
            }
            return View(speler);
        }

        // POST: Spelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "playerID,accountType,firstName,lastName,alias,schoolClass,targetID")] Speler speler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speler);
        }

        // GET: Spelers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speler speler = db.Spelers.Find(id);
            if (speler == null)
            {
                return HttpNotFound();
            }
            return View(speler);
        }

        // POST: Spelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Speler speler = db.Spelers.Find(id);
            db.Spelers.Remove(speler);
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
