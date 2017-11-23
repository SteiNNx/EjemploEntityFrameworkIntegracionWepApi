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
    public class TALLAsController : ApiController
    {
        private TiendaOnLineEntities db = new TiendaOnLineEntities();

        // GET: api/TALLAs
        public IQueryable<TALLA> GetTALLA()
        {
            return db.TALLA;
        }

        // GET: api/TALLAs/5
        [ResponseType(typeof(TALLA))]
        public IHttpActionResult GetTALLA(int id)
        {
            TALLA tALLA = db.TALLA.Find(id);
            if (tALLA == null)
            {
                return NotFound();
            }

            return Ok(tALLA);
        }

        // PUT: api/TALLAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTALLA(int id, TALLA tALLA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tALLA.Id)
            {
                return BadRequest();
            }

            db.Entry(tALLA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TALLAExists(id))
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

        // POST: api/TALLAs
        [ResponseType(typeof(TALLA))]
        public IHttpActionResult PostTALLA(TALLA tALLA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TALLA.Add(tALLA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tALLA.Id }, tALLA);
        }

        // DELETE: api/TALLAs/5
        [ResponseType(typeof(TALLA))]
        public IHttpActionResult DeleteTALLA(int id)
        {
            TALLA tALLA = db.TALLA.Find(id);
            if (tALLA == null)
            {
                return NotFound();
            }

            db.TALLA.Remove(tALLA);
            db.SaveChanges();

            return Ok(tALLA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TALLAExists(int id)
        {
            return db.TALLA.Count(e => e.Id == id) > 0;
        }
    }
}