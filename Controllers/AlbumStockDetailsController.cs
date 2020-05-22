using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EverestAlbumLibrary.Models;

namespace EverestAlbumLibrary.Controllers
{
    public class AlbumStockDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AlbumStockDetails
        public ActionResult Index()
        {
            var albumStockDetails = db.AlbumStockDetails.Include(a => a.Album);
            return View(albumStockDetails.ToList());
        }

        // GET: AlbumStockDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumStockDetails albumStockDetails = db.AlbumStockDetails.Find(id);
            if (albumStockDetails == null)
            {
                return HttpNotFound();
            }
            return View(albumStockDetails);
        }

        // GET: AlbumStockDetails/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Tittle");
            return View();
        }

        // POST: AlbumStockDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AddedDate,AlbumId")] AlbumStockDetails albumStockDetails)
        {
            if (ModelState.IsValid)
            {
                db.AlbumStockDetails.Add(albumStockDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Tittle", albumStockDetails.AlbumId);
            return View(albumStockDetails);
        }

        // GET: AlbumStockDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumStockDetails albumStockDetails = db.AlbumStockDetails.Find(id);
            if (albumStockDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Tittle", albumStockDetails.AlbumId);
            return View(albumStockDetails);
        }

        // POST: AlbumStockDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AddedDate,AlbumId")] AlbumStockDetails albumStockDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albumStockDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Tittle", albumStockDetails.AlbumId);
            return View(albumStockDetails);
        }

        // GET: AlbumStockDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumStockDetails albumStockDetails = db.AlbumStockDetails.Find(id);
            if (albumStockDetails == null)
            {
                return HttpNotFound();
            }
            return View(albumStockDetails);
        }

        // POST: AlbumStockDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumStockDetails albumStockDetails = db.AlbumStockDetails.Find(id);
            db.AlbumStockDetails.Remove(albumStockDetails);
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
