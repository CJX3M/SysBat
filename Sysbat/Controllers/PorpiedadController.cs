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
    public class PorpiedadController : Controller
    {
        private SysbatContext db = new SysbatContext();

        private List<Propiedad> listaPropiedades;
        private List<Propiedad> ListaPropiedades
        {
            get
            {
                if (listaPropiedades == null)
                {
                    listaPropiedades = db.Propiedades.ToList();
                    listaPropiedades.ForEach(delegate(Propiedad p)
                    {
                        int oidObjeto = 0;
                        if (Int32.TryParse(p.Tipo, out oidObjeto))
                        {
                            p.Objeto = db.Objetos.Find(oidObjeto);
                        }
                    });
                }
                return listaPropiedades;
            }
        }
        //
        // GET: /Porpiedad/

        public ActionResult Index()
        {
            return View(ListaPropiedades);
        }

        //
        // GET: /Porpiedad/Details/5

        public ActionResult Details(int id = 0)
        {
            Propiedad propiedad = ListaPropiedades.Find(p => p.Oid == id);
            if (propiedad == null)
            {
                return HttpNotFound();
            }
            int dummy;
            ViewBag.Tipo = propiedad.Objeto != null ? propiedad.Objeto.Nombre : propiedad.Tipo;
            return View(propiedad);
        }

        //
        // GET: /Porpiedad/Create

        public ActionResult Create()
        {
            CrearDatosDropDowns("");
            return PartialView();
        }

        //
        // POST: /Porpiedad/Create

        [HttpPost]
        public ActionResult Create(Propiedad propiedad)
        {
            if (ModelState.IsValid)
            {
                db.Propiedades.Add(propiedad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propiedad);
        }

        //
        // GET: /Porpiedad/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Propiedad propiedad = db.Propiedades.Find(id);
            if (propiedad == null)
            {
                return HttpNotFound();
            }
            CrearDatosDropDowns(propiedad.Tipo);
            return View(propiedad);
        }

        //
        // POST: /Porpiedad/Edit/5

        [HttpPost]
        public ActionResult Edit(Propiedad propiedad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propiedad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propiedad);
        }

        //
        // GET: /Porpiedad/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Propiedad propiedad = db.Propiedades.Find(id);
            if (propiedad == null)
            {
                return HttpNotFound();
            }
            return View(propiedad);
        }

        //
        // POST: /Porpiedad/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Propiedad propiedad = db.Propiedades.Find(id);
            db.Propiedades.Remove(propiedad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void CrearDatosDropDowns(string valorSeleccionado)
        {
            List<TipoProdpiedad> lista = new List<TipoProdpiedad>();
            lista.Add(new TipoProdpiedad
            {
                valor = "".GetType().ToString(),
                texto = "String"
            });
            lista.Add(new TipoProdpiedad
            {
                valor = DateTime.Now.GetType().ToString(),
                texto = "Fecha"
            });
            lista.Add(new TipoProdpiedad
            {
                valor = Int32.MinValue.GetType().ToString(),
                texto = "Entero"
            });
            lista.Add(new TipoProdpiedad
            {
                valor = Decimal.MinValue.GetType().ToString(),
                texto = "Entero"
            });
            lista.Add(new TipoProdpiedad
            {
                valor = true.GetType().ToString(),
                texto = "Booleano"
            });
            lista.Add(new TipoProdpiedad
            {
                valor = "Objeto",
                texto = "Objeto"
            });
            if (valorSeleccionado != "")
            {
                int dummy = 0;
                if (Int32.TryParse(valorSeleccionado, out dummy))
                {
                    ViewBag.ListaTipos = new SelectList(lista, "valor", "texto", "Objeto");
                    ViewBag.MostrarObjetoDdl = "table";
                }
                else
                {
                    ViewBag.ListaTipos = new SelectList(lista, "valor", "texto", valorSeleccionado);
                    ViewBag.MostrarObjetoDdl = "none";
                }
            }
            else
                ViewBag.ListaTipos = new SelectList(lista, "valor", "texto", "");
            ViewBag.ListaTiposObjetos = new SelectList(db.Objetos.ToList(), "Oid", "Nombre", valorSeleccionado);
        }
    }

    internal struct TipoProdpiedad {
        public string valor { get; set; }
        public string texto { get; set; }
    }
}