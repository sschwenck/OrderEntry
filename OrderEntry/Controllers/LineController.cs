using System;
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
    public class LineController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Line/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Lines.ToList());
        }

        // GET: /Line/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line line = db.Lines.Find(id);
            if (line == null)
            {
                return HttpNotFound();
            }
            return View(line);
        }

        // GET: /Line/Create
        [Authorize]
        public ActionResult Create(int orderID)
        {
           var line = new Line { OrderID = orderID };

            return View(line);
        }

        // POST: /Line/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineID,OrderID,LineNo,ProductNumber,Description,QtyOrd,QtyShip,Price,Discount,NetAmt,MarginAmt,MarginPct,Unit,OrderNumber")] Line line)
        {
            if (ModelState.IsValid)
            {
               var lines = db.Lines.Where(l => l.OrderID == line.OrderID);

               line.LineNo = lines.Count() + 1;

               line.NetAmt = CalculateNetAmount(line);

               db.Lines.Add(line);
                db.SaveChanges();
                return RedirectToAction("Details", "Order", routeValues: new { id = line.OrderID });
            }

            return View(line);
        }

        // GET: /Line/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line line = db.Lines.Find(id);
            if (line == null)
            {
                return HttpNotFound();
            }
            return View(line);
        }

        // POST: /Line/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LineID,LineNo,Product,Description,QtyOrd,QtyShip,Price,Discount,NetAmt,MarginAmt,MarginPct,Unit")] Line line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(line);
        }

        // GET: /Line/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Line line = db.Lines.Find(id);
            if (line == null)
            {
                return HttpNotFound();
            }
            return View(line);
        }

        // POST: /Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Line line = db.Lines.Find(id);
            db.Lines.Remove(line);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       private decimal CalculateNetAmount(Line line)
       {
          var netAmt = line.Price;

          if (line.Discount != 0)
          {
             netAmt = line.Price - line.Discount;
          }
          if (line.MarginAmt != 0)
          {
             //calculate margin, we should have a cost when we start creating products
          }

          return netAmt;
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
