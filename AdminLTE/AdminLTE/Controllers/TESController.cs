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
    public class TESController : Controller
    {
        private Test_OnlineEntities1 db = new Test_OnlineEntities1();

        // GET: TES
        public ActionResult Index()
        {
            return View("ListCreate");
            //return View(db.TES.ToList());
        }

        // GET: TES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TES tES = db.TES.Find(id);
            if (tES == null)
            {
                return HttpNotFound();
            }
            return View(tES);
        }

        // GET: TES/Create
        public ActionResult ListCreate()
        {
            ViewBag.tes = db.TES.ToList();
            ViewBag.Title = "Home Page";
            return View();
        }

        // GET: TES/Create
        public ActionResult Create()
        {
            TES tES = new TES();
            ViewData["tanggal"] = DateTime.Now;
            ViewBag.tanggal = DateTime.Now;
            ViewBag.Title = "Home Page";
            ViewBag.tES = tES;
            return View(tES);
        }

        // POST: TES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TES,Created_by,Created_date,Modified_by,NAMA_TES,TGL_TES")] TES tES)
        {
           
            if (ModelState.IsValid)
            {
                tES.Created_by = "Admin";
                tES.Created_date = DateTime.Now;
                db.TES.Add(tES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tES);
        }

        // GET: TES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TES tES = db.TES.Find(id);
            if (tES == null)
            {
                return HttpNotFound();
            }
            return View(tES);
        }

        // POST: TES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TES,Created_by,Created_date,Modified_by,NAMA_TES,TGL_TES")] TES tES)
        {
            if (ModelState.IsValid)
            {
                tES.Modified_by = "Admin";
                tES.Created_date = DateTime.Now;
                db.Entry(tES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tES);
        }

        // GET: TES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TES tES = db.TES.Find(id);
            if (tES == null)
            {
                return HttpNotFound();
            }
            return View(tES);
        }

        // POST: TES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TES tES = db.TES.Find(id);
            db.TES.Remove(tES);
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
