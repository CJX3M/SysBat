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
    public class propvalapiController : ApiController
    {
        private SysbatContext db = new SysbatContext();

        // GET api/propvalapi
        public IEnumerable<PropiedadValores> GetPropiedadValores()
        {
            return db.PorpiedadesValores.AsEnumerable();
        }

        // GET api/propvalapi/5
        public PropiedadValores GetPropiedadValores(int id)
        {
            PropiedadValores propiedadvalores = db.PorpiedadesValores.Find(id);
            if (propiedadvalores == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return propiedadvalores;
        }

        // PUT api/propvalapi/5
        public HttpResponseMessage PutPropiedadValores(int id, PropiedadValores propiedadvalores)
        {
            if (ModelState.IsValid && id == propiedadvalores.Oid)
            {
                db.Entry(propiedadvalores).State = EntityState.Modified;

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
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/propvalapi
        public HttpResponseMessage PostPropiedadValores(PropiedadValores propiedadvalores)
        {
            if (ModelState.IsValid)
            {
                db.PorpiedadesValores.Add(propiedadvalores);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, propiedadvalores);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = propiedadvalores.Oid }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/propvalapi/5
        public HttpResponseMessage DeletePropiedadValores(int id)
        {
            PropiedadValores propiedadvalores = db.PorpiedadesValores.Find(id);
            if (propiedadvalores == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.PorpiedadesValores.Remove(propiedadvalores);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, propiedadvalores);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}