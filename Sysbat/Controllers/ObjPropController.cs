using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Sysbat.Models;

namespace Sysbat.Controllers
{
    public class ObjPropController : HomeController {}

    public class ObjPropApiController : ApiController
    {
        private SysbatContext db = new SysbatContext();
        [HttpGet]
        public IEnumerable<Objeto> GetObjetos()
        {
            return db.Objetos.AsNoTracking().AsEnumerable();
        }
        [HttpGet]
        public IEnumerable<Propiedad> GetPropiedadesLibres(int id)
        {
            if (id == -1)
                return null;
            var propiedadesLibres = db.Propiedades.AsEnumerable();
            var objetoPropiedades = GetPropiedadesObjeto(id);
            propiedadesLibres = propiedadesLibres.Except(objetoPropiedades);

            return propiedadesLibres;
        }
        [HttpGet]
        public IEnumerable<Propiedad> GetPropiedadesObjeto(int id)
        {
            return db.Objetos.Find(id).Propiedades;
        }
        [HttpPost]
        public HttpResponseMessage AgregarPropiedadObjeto(ObjetoPropiedad propObj)
        {
            if (!ModelState.IsValid || propObj.ObjetoOid == -1 || propObj.PropiedadOid == -1)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            Objeto objeto = db.Objetos.Find(propObj.ObjetoOid);

            if (objeto == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Propiedad propiedad = db.Propiedades.Find(propObj.PropiedadOid);

            if (propiedad == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

           
            if (!objeto.Propiedades.Any(p => p.Oid == propiedad.Oid))
                objeto.Propiedades.Add(propiedad);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }
        [HttpPost]
        public HttpResponseMessage BorrarPropiedadObjeto(ObjetoPropiedad propObj)
        {
            Objeto objeto = db.Objetos.Find(propObj.ObjetoOid);

            if (objeto == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Propiedad propiedad = db.Propiedades.Find(propObj.PropiedadOid);

            if (propiedad == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (objeto.Propiedades.Any(p => p.Oid == propiedad.Oid))
                objeto.Propiedades.Remove(propiedad);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

    public class ObjetoPropiedad
    {
        public int ObjetoOid { get; set; }
        public int PropiedadOid { get; set; }
    }
}