using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarVehicle.Models;
using CarVehicle.Reposetory;

namespace CarVehicle.Controllers
{
    public class SheduleVehicleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /SheduleVehicle/
        public ActionResult Index()
        {
            var shedulevehicles = db.SheduleVehicles.Include(s => s.SaveVehicles).Include(s => s.Shift);
            return View(shedulevehicles.ToList());
        }

        // GET: /SheduleVehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SheduleVehicle shedulevehicle = db.SheduleVehicles.Find(id);
            if (shedulevehicle == null)
            {
                return HttpNotFound();
            }
            return View(shedulevehicle);
        }

        // GET: /SheduleVehicle/Create
        public ActionResult Create()
        {
            ViewBag.SelectVehicle = new SelectList(db.SaveVehicles, "ID", "RegNo");
            ViewBag.SelectShift = new SelectList(db.Shifts, "ID", "ShiftName");
            return View();
        }

        // POST: /SheduleVehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,SelectVehicle,SelectDate,SelectShift,BookedBy,Address")] SheduleVehicle shedulevehicle)
        {
            if (ModelState.IsValid)
            {
                db.SheduleVehicles.Add(shedulevehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SelectVehicle = new SelectList(db.SaveVehicles, "ID", "RegNo", shedulevehicle.SelectVehicle);
            ViewBag.SelectShift = new SelectList(db.Shifts, "ID", "ShiftName", shedulevehicle.SelectShift);
            return View(shedulevehicle);
        }

        // GET: /SheduleVehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SheduleVehicle shedulevehicle = db.SheduleVehicles.Find(id);
            if (shedulevehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelectVehicle = new SelectList(db.SaveVehicles, "ID", "RegNo", shedulevehicle.SelectVehicle);
            ViewBag.SelectShift = new SelectList(db.Shifts, "ID", "ShiftName", shedulevehicle.SelectShift);
            return View(shedulevehicle);
        }

        // POST: /SheduleVehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,SelectVehicle,SelectDate,SelectShift,BookedBy,Address")] SheduleVehicle shedulevehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shedulevehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SelectVehicle = new SelectList(db.SaveVehicles, "ID", "RegNo", shedulevehicle.SelectVehicle);
            ViewBag.SelectShift = new SelectList(db.Shifts, "ID", "ShiftName", shedulevehicle.SelectShift);
            return View(shedulevehicle);
        }

        // GET: /SheduleVehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SheduleVehicle shedulevehicle = db.SheduleVehicles.Find(id);
            if (shedulevehicle == null)
            {
                return HttpNotFound();
            }
            return View(shedulevehicle);
        }

        // POST: /SheduleVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SheduleVehicle shedulevehicle = db.SheduleVehicles.Find(id);
            db.SheduleVehicles.Remove(shedulevehicle);
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
