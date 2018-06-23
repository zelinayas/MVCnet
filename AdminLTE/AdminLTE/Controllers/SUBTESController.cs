using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminLTE.Models;

namespace AdminLTE.Controllers
{
    public class SUBTESController : Controller
    {
        private Test_OnlineEntities1 db = new Test_OnlineEntities1();

        // GET: SUBTES
        public ActionResult Index()
        {
            var sUBTES = db.SUBTES.Include(s => s.TES);
            return View(sUBTES.ToList());
        }

        // GET: SUBTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBTES sUBTES = db.SUBTES.Find(id);
            if (sUBTES == null)
            {
                return HttpNotFound();
            }
            return View(sUBTES);
        }

        // GET: SUBTES/Create
        public ActionResult Create()
        {
            ViewBag.ID_TES = new SelectList(db.TES, "ID_TES", "Created_by");
            return View();
        }

        // POST: SUBTES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SUBTES,ID_TES,DURASI_SUB,Created_by,Created_date,Modified_by,Is_Active,NAMA_SUBTES")] SUBTES sUBTES)
        {
            if (ModelState.IsValid)
            {
                db.SUBTES.Add(sUBTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TES = new SelectList(db.TES, "ID_TES", "Created_by", sUBTES.ID_TES);
            return View(sUBTES);
        }

        // GET: SUBTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBTES sUBTES = db.SUBTES.Find(id);
            if (sUBTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TES = new SelectList(db.TES, "ID_TES", "Created_by", sUBTES.ID_TES);
            return View(sUBTES);
        }

        // POST: SUBTES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SUBTES,ID_TES,DURASI_SUB,Created_by,Created_date,Modified_by,Is_Active,NAMA_SUBTES")] SUBTES sUBTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUBTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TES = new SelectList(db.TES, "ID_TES", "Created_by", sUBTES.ID_TES);
            return View(sUBTES);
        }

        // GET: SUBTES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBTES sUBTES = db.SUBTES.Find(id);
            if (sUBTES == null)
            {
                return HttpNotFound();
            }
            return View(sUBTES);
        }

        // POST: SUBTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUBTES sUBTES = db.SUBTES.Find(id);
            db.SUBTES.Remove(sUBTES);
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
