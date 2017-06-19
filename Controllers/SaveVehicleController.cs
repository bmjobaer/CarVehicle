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
    public class SaveVehicleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /SaveVehicle/
        public ActionResult Index()
        {
            return View(db.SaveVehicles.ToList());
        }

        // GET: /SaveVehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaveVehicle savevehicle = db.SaveVehicles.Find(id);
            if (savevehicle == null)
            {
                return HttpNotFound();
            }
            return View(savevehicle);
        }

        // GET: /SaveVehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SaveVehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,RegNo,EngineNo")] SaveVehicle savevehicle)
        {
            if (ModelState.IsValid)
            {
                db.SaveVehicles.Add(savevehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(savevehicle);
        }

        // GET: /SaveVehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaveVehicle savevehicle = db.SaveVehicles.Find(id);
            if (savevehicle == null)
            {
                return HttpNotFound();
            }
            return View(savevehicle);
        }

        // POST: /SaveVehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,RegNo,EngineNo")] SaveVehicle savevehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(savevehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(savevehicle);
        }

        // GET: /SaveVehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaveVehicle savevehicle = db.SaveVehicles.Find(id);
            if (savevehicle == null)
            {
                return HttpNotFound();
            }
            return View(savevehicle);
        }

        // POST: /SaveVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaveVehicle savevehicle = db.SaveVehicles.Find(id);
            db.SaveVehicles.Remove(savevehicle);
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
