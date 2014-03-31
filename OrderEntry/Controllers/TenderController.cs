﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderEntry.Models;

namespace OrderEntry.Controllers
{
    public class TenderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Tender/
        public ActionResult Index()
        {
            return View(db.Tenders.ToList());
        }

        // GET: /Tender/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.Tenders.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // GET: /Tender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tender/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TenderID,TenderType,TenderAmount")] Tender tender)
        {
            if (ModelState.IsValid)
            {
                db.Tenders.Add(tender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tender);
        }

        // GET: /Tender/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.Tenders.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // POST: /Tender/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TenderID,TenderType,TenderAmount")] Tender tender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tender);
        }

        // GET: /Tender/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.Tenders.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // POST: /Tender/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tender tender = db.Tenders.Find(id);
            db.Tenders.Remove(tender);
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
