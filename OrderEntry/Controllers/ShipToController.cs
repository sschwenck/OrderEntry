using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderEntry.Models;

namespace OrderEntry
{
    public class ShipToController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ShipTo/
        public ActionResult Index()
        {
            return View(db.ShipTos.ToList());
        }

        // GET: /ShipTo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipTo shipto = db.ShipTos.Find(id);
            if (shipto == null)
            {
                return HttpNotFound();
            }
            return View(shipto);
        }

        // GET: /ShipTo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ShipTo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ShipToID,ShipToNo,ShipToName")] ShipTo shipto)
        {
            if (ModelState.IsValid)
            {
                db.ShipTos.Add(shipto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipto);
        }

        // GET: /ShipTo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipTo shipto = db.ShipTos.Find(id);
            if (shipto == null)
            {
                return HttpNotFound();
            }
            return View(shipto);
        }

        // POST: /ShipTo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ShipToID,ShipToNo,ShipToName")] ShipTo shipto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipto);
        }

        // GET: /ShipTo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipTo shipto = db.ShipTos.Find(id);
            if (shipto == null)
            {
                return HttpNotFound();
            }
            return View(shipto);
        }

        // POST: /ShipTo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipTo shipto = db.ShipTos.Find(id);
            db.ShipTos.Remove(shipto);
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
