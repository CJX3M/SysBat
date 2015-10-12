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
    public class ObjetoController : Controller
    {
        private SysbatContext db = Utils.SysBatLibContext.GetContext();

        //
        // GET: /Objeto/

        public ActionResult Index()
        {
            return View(db.Objetos.ToList());
        }

        //
        // GET: /Objeto/Details/5

        public ActionResult Details(int id = 0)
        {
            Objeto objeto = db.Objetos.Find(id);
            if (objeto == null)
            {
                return HttpNotFound();
            }
            return PartialView(objeto);
        }

        //
        // GET: /Objeto/Create

        public ActionResult Create()
        {
            return PartialView();
        }

        //
        // POST: /Objeto/Create

        [HttpPost]
        public ActionResult Create(Objeto objeto)
        {
            objeto.FechaCreacion = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Objetos.Add(objeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objeto);
        }

        //
        // GET: /Objeto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Objeto objeto = db.Objetos.Find(id);
            if (objeto == null)
            {
                return HttpNotFound();
            }
            return View(objeto);
        }

        //
        // POST: /Objeto/Edit/5

        [HttpPost]
        public ActionResult Edit(Objeto objeto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objeto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objeto);
        }

        //
        // GET: /Objeto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Objeto objeto = db.Objetos.Find(id);
            if (objeto == null)
            {
                return HttpNotFound();
            }
            return View(objeto);
        }

        //
        // POST: /Objeto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Objeto objeto = db.Objetos.Find(id);
            db.Objetos.Remove(objeto);
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