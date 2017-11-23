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
    public class PRENDAsController : ApiController
    {
        private TiendaOnLineEntities db = new TiendaOnLineEntities();

        // GET: api/PRENDAs
        public IQueryable<PRENDA> GetPRENDA()
        {
            return db.PRENDA;
        }

        // GET: api/PRENDAs/5
        [ResponseType(typeof(PRENDA))]
        public IHttpActionResult GetPRENDA(int id)
        {
            PRENDA pRENDA = db.PRENDA.Find(id);
            if (pRENDA == null)
            {
                return NotFound();
            }

            return Ok(pRENDA);
        }

        // PUT: api/PRENDAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRENDA(int id, PRENDA pRENDA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRENDA.Id)
            {
                return BadRequest();
            }

            db.Entry(pRENDA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRENDAExists(id))
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

        // POST: api/PRENDAs
        [ResponseType(typeof(PRENDA))]
        public IHttpActionResult PostPRENDA(PRENDA pRENDA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRENDA.Add(pRENDA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pRENDA.Id }, pRENDA);
        }

        // DELETE: api/PRENDAs/5
        [ResponseType(typeof(PRENDA))]
        public IHttpActionResult DeletePRENDA(int id)
        {
            PRENDA pRENDA = db.PRENDA.Find(id);
            if (pRENDA == null)
            {
                return NotFound();
            }

            db.PRENDA.Remove(pRENDA);
            db.SaveChanges();

            return Ok(pRENDA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRENDAExists(int id)
        {
            return db.PRENDA.Count(e => e.Id == id) > 0;
        }
    }
}