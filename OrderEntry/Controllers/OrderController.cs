using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderEntry.Models;
using OrderEntry.Models.Orders;

namespace OrderEntry.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Order/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            else
            {
               var vm = new DetailsViewModel { CurrentOrder = order, LineForDisplay = new Line() };
               return View(vm);
            }
        }

        // GET: /Order/Create
        public ActionResult Create()
        {
           var order = new Order();
            return View(order);
        }

        // POST: /Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OrderID,OrderNumber,OrderSuffix,OrderType,CustomerNumber,WarehouseNumber,CustomerPO,TakenBy,ShipTo,Taxable")] Order order)
        {
           if (order.OrderNumber != 0 && order.CustomerNumber != 0 && order.WarehouseNumber != 0)
           {
              var customer = db.Customers.FirstOrDefault(c => c.CustomerNumber == order.CustomerNumber);
              var warehouse = db.Warehouses.FirstOrDefault(w => w.WarehouseNumber == order.WarehouseNumber);

              if (customer != null)
              {
                 //order.Customer = customer;
              }
              else
              {
                 return View(order);
              }

              if (warehouse != null)
              {
                 //order.Warehouse = warehouse;
              }
              else
              {
                 return View(order);
              }

              db.Orders.Add(order);
              db.SaveChanges();
              return RedirectToAction("Details", new { id = order.OrderID });
           }

            return View(order);
        }

        // GET: /Order/Maintain
        public ActionResult Maintain()
        {
           MaintainViewModel mvm = new MaintainViewModel();
           mvm.Orders = db.Orders.ToList();
           mvm.SearchOrderCriteria = new Order();

           return View(mvm);
        }

        // GET: /Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            else
            {
               var customer = db.Customers.FirstOrDefault(c => c.CustomerNumber == order.CustomerNumber);
               var warehouse = db.Warehouses.FirstOrDefault(w => w.WarehouseNumber == order.WarehouseNumber);

               if (customer != null)
               {
                  //order.Customer = customer;
               }
               if (warehouse != null)
               {
                  //order.Warehouse = warehouse;
               }

               return View(order);
            }
        }

        // POST: /Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OrderID,OrderNumber,OrderSuffix,OrderType,CustomerNumber,WarehouseNumber,CustomerPO,TakenBy,Taxable")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: /Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: /Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
