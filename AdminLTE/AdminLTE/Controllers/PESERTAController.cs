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
    public class PESERTAController : Controller
    {
        private Test_OnlineEntities1 db = new Test_OnlineEntities1();

        // GET: PESERTA
        public ActionResult Index()
        {
            var pESERTA = db.PESERTA.Include(p => p.PROFIL_PESERTA);
            return View(pESERTA.ToList());
        }

        // GET: PESERTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESERTA pESERTA = db.PESERTA.Find(id);
            if (pESERTA == null)
            {
                return HttpNotFound();
            }
            return View(pESERTA);
        }

        // GET: PESERTA/Create
        public ActionResult Create()
        {
            ViewBag.ID_PROFIL = new SelectList(db.PROFIL_PESERTA, "ID_PROFIL", "NAMA_PESERTA");
            return View();
        }

        // POST: PESERTA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PESERTA,ID_PROFIL,EMAIL,PASSWORD,Created_by,Created_date,Modified_by,Is_Active")] PESERTA pESERTA)
        {
            if (ModelState.IsValid)
            {
                db.PESERTA.Add(pESERTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PROFIL = new SelectList(db.PROFIL_PESERTA, "ID_PROFIL", "NAMA_PESERTA", pESERTA.ID_PROFIL);
            return View(pESERTA);
        }

        // GET: PESERTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESERTA pESERTA = db.PESERTA.Find(id);
            if (pESERTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PROFIL = new SelectList(db.PROFIL_PESERTA, "ID_PROFIL", "NAMA_PESERTA", pESERTA.ID_PROFIL);
            return View(pESERTA);
        }

        // POST: PESERTA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PESERTA,ID_PROFIL,EMAIL,PASSWORD,Created_by,Created_date,Modified_by,Is_Active")] PESERTA pESERTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pESERTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PROFIL = new SelectList(db.PROFIL_PESERTA, "ID_PROFIL", "NAMA_PESERTA", pESERTA.ID_PROFIL);
            return View(pESERTA);
        }

        // GET: PESERTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESERTA pESERTA = db.PESERTA.Find(id);
            if (pESERTA == null)
            {
                return HttpNotFound();
            }
            return View(pESERTA);
        }

        // POST: PESERTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PESERTA pESERTA = db.PESERTA.Find(id);
            db.PESERTA.Remove(pESERTA);
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
