using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysbatLib.Models;

namespace Sysbat.Controllers
{
    public class ObjValController : Controller
    {
        private SysbatContext db = Utils.SysBatLibContext.GetContext();

        //
        // GET: /ObjVal/

        public ActionResult Index()
        {
            var objetosvalores = db.ObjetosValores.Include(o => o.Objeto);
            return View(objetosvalores.ToList());
        }

        //
        // GET: /ObjVal/Details/5

        public ActionResult Details(int id = 0)
        {
            ObjetoValores objetovalores = db.ObjetosValores.Find(id);
            if (objetovalores == null)
            {
                return HttpNotFound();
            }
            return View(objetovalores);
        }

        //
        // GET: /ObjVal/Create

        public ActionResult Create()
        {
            ViewBag.Oid = new SelectList(db.Objetos, "Oid", "Nombre");
            return View();
        }

        //
        // POST: /ObjVal/Create

        [HttpPost]
        public ActionResult Create(ObjetoValores objetovalores)
        {
            if (ModelState.IsValid)
            {
                db.ObjetosValores.Add(objetovalores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Oid = new SelectList(db.Objetos, "Oid", "Nombre", objetovalores.Oid);
            return View(objetovalores);
        }

        //
        // GET: /ObjVal/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ObjetoValores objetovalores = db.ObjetosValores.Find(id);
            if (objetovalores == null)
            {
                return HttpNotFound();
            }
            ViewBag.Oid = new SelectList(db.Objetos, "Oid", "Nombre", objetovalores.Oid);
            return View(objetovalores);
        }

        //
        // POST: /ObjVal/Edit/5

        [HttpPost]
        public ActionResult Edit(ObjetoValores objetovalores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objetovalores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Oid = new SelectList(db.Objetos, "Oid", "Nombre", objetovalores.Oid);
            return View(objetovalores);
        }

        //
        // GET: /ObjVal/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ObjetoValores objetovalores = db.ObjetosValores.Find(id);
            if (objetovalores == null)
            {
                return HttpNotFound();
            }
            return View(objetovalores);
        }

        //
        // POST: /ObjVal/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjetoValores objetovalores = db.ObjetosValores.Find(id);
            db.ObjetosValores.Remove(objetovalores);
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