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
using SysbatLib.Models;

namespace RatesAdmin.Controllers
{
    public class ObjetosController : ApiController
    {
        private SysbatContext db = Utils.ContextDB.GetContext();

        // GET api/Default1
        public IEnumerable<Objeto> GetObjetos()
        {
            try
            {
                var objetos = db.Objetos.AsEnumerable();
                return objetos;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        // GET api/Default1/5
        public Objeto GetObjeto(int id)
        {
            Objeto objeto = db.Objetos.Find(id);
            if (objeto == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return objeto;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutObjeto(int id, Objeto objeto)
        {
            if (ModelState.IsValid && id == objeto.Oid)
            {
                db.Entry(objeto).State = EntityState.Modified;

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

        // POST api/Default1
        public HttpResponseMessage PostObjeto(Objeto objeto)
        {
            if (ModelState.IsValid)
            {
                db.Objetos.Add(objeto);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, objeto);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = objeto.Oid }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteObjeto(int id)
        {
            Objeto objeto = db.Objetos.Find(id);
            if (objeto == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Objetos.Remove(objeto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, objeto);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}