using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3;

namespace WebApplication3.Controllers
{
    public class BookingsController : Controller
    {
        private toursimEntities1 db = new toursimEntities1();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.bookings.Include(b => b.package).Include(b => b.user);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.package_id = new SelectList(db.packages, "package_id", "packge_name");
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "booking_id,user_id,package_id,cost_per_ticket,total,payment_mode,payment_status")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.package_id = new SelectList(db.packages, "package_id", "packge_name", booking.package_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", booking.user_id);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.package_id = new SelectList(db.packages, "package_id", "packge_name", booking.package_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", booking.user_id);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_id,user_id,package_id,cost_per_ticket,total,payment_mode,payment_status")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.package_id = new SelectList(db.packages, "package_id", "packge_name", booking.package_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", booking.user_id);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            booking booking = db.bookings.Find(id);
            db.bookings.Remove(booking);
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
