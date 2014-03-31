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
        public ActionResult Index()
        {
            return View(db.Lines.ToList());
        }

        // GET: /Line/Details/5
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
        public ActionResult Create(int orderID)
        {
           int varID = orderID;
           var line = new Line { OrderNumber = orderID };

            return View(line);
        }

        // POST: /Line/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LineID,LineNo,ProductNumber,Description,QtyOrd,QtyShip,Price,Discount,NetAmt,MarginAmt,MarginPct,Unit,OrderNumber")] Line line)
        {
            if (ModelState.IsValid)
            {
               var order = db.Orders.FirstOrDefault(o => o.OrderID == line.OrderNumber);

               var newLinesList = new List<Line>();
               if (order.Lines != null && order.Lines.Any())
               {
                  newLinesList = order.Lines.ToList();
               }
               newLinesList.Add(line);
               order.Lines = newLinesList;

               db.Entry(order).State = EntityState.Modified;
                  //db.Entry(line).State = EntityState.Modified;
                //db.Lines.Add(line);
                db.SaveChanges();
                return RedirectToAction("Details", "Order", routeValues: new { id = order.OrderID });
            }

            return View(line);
        }

        // GET: /Line/Edit/5
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Line line = db.Lines.Find(id);
            db.Lines.Remove(line);
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
