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
    public class SOALController : Controller
    {
        private Test_OnlineEntities1 db = new Test_OnlineEntities1();

        // GET: SOAL
        public ActionResult Index()
        {
            var sOAL = db.SOAL.Include(s => s.KELOMPOK_SOAL).Include(s => s.TIPE_SOAL).Include(s => s.SUBTES);
            return View(sOAL.ToList());
        }

        // GET: SOAL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOAL sOAL = db.SOAL.Find(id);
            if (sOAL == null)
            {
                return HttpNotFound();
            }
            return View(sOAL);
        }

        // GET: SOAL/Create
        public ActionResult Create()
        {
            ViewBag.ID_KELOMPOKSOAL = new SelectList(db.KELOMPOK_SOAL, "ID_KELOMPOKSOAL", "NAMA_KELOMPOKSOAL");
            ViewBag.ID_TIPESOAL = new SelectList(db.TIPE_SOAL, "ID_TIPESOAL", "NAMA_TIPE");
            ViewBag.ID_SUBTES = new SelectList(db.SUBTES, "ID_SUBTES", "Created_by");
            return View();
        }

        // POST: SOAL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SOAL,ID_KELOMPOKSOAL,ID_TIPESOAL,ISI_SOAL,NILAI_SOAL,Created_by,Created_date,Modified_by,ID_SUBTES")] SOAL sOAL)
        {
            if (ModelState.IsValid)
            {
                db.SOAL.Add(sOAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_KELOMPOKSOAL = new SelectList(db.KELOMPOK_SOAL, "ID_KELOMPOKSOAL", "NAMA_KELOMPOKSOAL", sOAL.ID_KELOMPOKSOAL);
            ViewBag.ID_TIPESOAL = new SelectList(db.TIPE_SOAL, "ID_TIPESOAL", "NAMA_TIPE", sOAL.ID_TIPESOAL);
            ViewBag.ID_SUBTES = new SelectList(db.SUBTES, "ID_SUBTES", "Created_by", sOAL.ID_SUBTES);
            return View(sOAL);
        }

        // GET: SOAL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOAL sOAL = db.SOAL.Find(id);
            if (sOAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_KELOMPOKSOAL = new SelectList(db.KELOMPOK_SOAL, "ID_KELOMPOKSOAL", "NAMA_KELOMPOKSOAL", sOAL.ID_KELOMPOKSOAL);
            ViewBag.ID_TIPESOAL = new SelectList(db.TIPE_SOAL, "ID_TIPESOAL", "NAMA_TIPE", sOAL.ID_TIPESOAL);
            ViewBag.ID_SUBTES = new SelectList(db.SUBTES, "ID_SUBTES", "Created_by", sOAL.ID_SUBTES);
            return View(sOAL);
        }

        // POST: SOAL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SOAL,ID_KELOMPOKSOAL,ID_TIPESOAL,ISI_SOAL,NILAI_SOAL,Created_by,Created_date,Modified_by,ID_SUBTES")] SOAL sOAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_KELOMPOKSOAL = new SelectList(db.KELOMPOK_SOAL, "ID_KELOMPOKSOAL", "NAMA_KELOMPOKSOAL", sOAL.ID_KELOMPOKSOAL);
            ViewBag.ID_TIPESOAL = new SelectList(db.TIPE_SOAL, "ID_TIPESOAL", "NAMA_TIPE", sOAL.ID_TIPESOAL);
            ViewBag.ID_SUBTES = new SelectList(db.SUBTES, "ID_SUBTES", "Created_by", sOAL.ID_SUBTES);
            return View(sOAL);
        }

        // GET: SOAL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOAL sOAL = db.SOAL.Find(id);
            if (sOAL == null)
            {
                return HttpNotFound();
            }
            return View(sOAL);
        }

        // POST: SOAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOAL sOAL = db.SOAL.Find(id);
            db.SOAL.Remove(sOAL);
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
