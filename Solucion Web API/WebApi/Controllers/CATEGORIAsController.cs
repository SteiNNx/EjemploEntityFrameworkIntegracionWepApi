using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CATEGORIAsController : ApiController
    {
        private TiendaOnLineEntities db = new TiendaOnLineEntities();

        // GET: api/CATEGORIAs
        public IQueryable<CATEGORIA> GetCATEGORIA()
        {
            return db.CATEGORIA;
        }

        // GET: api/CATEGORIAs/5
        [ResponseType(typeof(CATEGORIA))]
        public IHttpActionResult GetCATEGORIA(int id)
        {
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            if (cATEGORIA == null)
            {
                return NotFound();
            }

            return Ok(cATEGORIA);
        }

        // PUT: api/CATEGORIAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCATEGORIA(int id, CATEGORIA cATEGORIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cATEGORIA.Id)
            {
                return BadRequest();
            }

            db.Entry(cATEGORIA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CATEGORIAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CATEGORIAs
        [ResponseType(typeof(CATEGORIA))]
        public IHttpActionResult PostCATEGORIA(CATEGORIA cATEGORIA)
        {
           /* if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */
            db.CATEGORIA.Add(cATEGORIA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CATEGORIAExists(cATEGORIA.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cATEGORIA.Id }, cATEGORIA);
        }

        // DELETE: api/CATEGORIAs/5
        [ResponseType(typeof(CATEGORIA))]
        public IHttpActionResult DeleteCATEGORIA(int id)
        {
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            if (cATEGORIA == null)
            {
                return NotFound();
            }

            db.CATEGORIA.Remove(cATEGORIA);
            db.SaveChanges();

            return Ok(cATEGORIA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CATEGORIAExists(int id)
        {
            return db.CATEGORIA.Count(e => e.Id == id) > 0;
        }
    }
}