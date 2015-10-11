using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sysbat.Models;

namespace Sysbat.Controllers
{
    public class PropValController : Controller
    {
        private SysbatContext db = new SysbatContext();

        //
        // GET: /PropVal/

        public ActionResult Index()
        {
            return View(db.PorpiedadesValores.ToList());
        }

        //
        // GET: /PropVal/Details/5

        public ActionResult Details(int id = 0)
        {
            PropiedadValores propiedadvalores = db.PorpiedadesValores.Find(id);
            if (propiedadvalores == null)
            {
                return HttpNotFound();
            }
            return View(propiedadvalores);
        }

        //
        // GET: /PropVal/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PropVal/Create

        [HttpPost]
        public ActionResult Create(PropiedadValores propiedadvalores)
        {
            if (ModelState.IsValid)
            {
                db.PorpiedadesValores.Add(propiedadvalores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propiedadvalores);
        }

        //
        // GET: /PropVal/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PropiedadValores propiedadvalores = db.PorpiedadesValores.Find(id);
            if (propiedadvalores == null)
            {
                return HttpNotFound();
            }
            return View(propiedadvalores);
        }

        //
        // POST: /PropVal/Edit/5

        [HttpPost]
        public ActionResult Edit(PropiedadValores propiedadvalores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propiedadvalores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propiedadvalores);
        }

        //
        // GET: /PropVal/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PropiedadValores propiedadvalores = db.PorpiedadesValores.Find(id);
            if (propiedadvalores == null)
            {
                return HttpNotFound();
            }
            return View(propiedadvalores);
        }

        //
        // POST: /PropVal/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PropiedadValores propiedadvalores = db.PorpiedadesValores.Find(id);
            db.PorpiedadesValores.Remove(propiedadvalores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}