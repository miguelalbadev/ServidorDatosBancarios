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
using ServidorDatosBancarios.Models;

namespace ServidorDatosBancarios.Controllers
{
    public class CuentaBancariasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CuentaBancarias
        public IQueryable<CuentaBancaria> GetCuentaBancarias()
        {
            return db.CuentaBancarias;
        }

        // GET: api/CuentaBancarias/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult GetCuentaBancaria(long id)
        {
            CuentaBancaria cuentaBancaria = db.CuentaBancarias.Find(id);
            if (cuentaBancaria == null)
            {
                return NotFound();
            }

            return Ok(cuentaBancaria);
        }

        // PUT: api/CuentaBancarias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuentaBancaria(long id, CuentaBancaria cuentaBancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuentaBancaria.Id)
            {
                return BadRequest();
            }

            db.Entry(cuentaBancaria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaBancariaExists(id))
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

        // POST: api/CuentaBancarias
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult PostCuentaBancaria(CuentaBancaria cuentaBancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CuentaBancarias.Add(cuentaBancaria);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cuentaBancaria.Id }, cuentaBancaria);
        }

        // DELETE: api/CuentaBancarias/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult DeleteCuentaBancaria(long id)
        {
            CuentaBancaria cuentaBancaria = db.CuentaBancarias.Find(id);
            if (cuentaBancaria == null)
            {
                return NotFound();
            }

            db.CuentaBancarias.Remove(cuentaBancaria);
            db.SaveChanges();

            return Ok(cuentaBancaria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuentaBancariaExists(long id)
        {
            return db.CuentaBancarias.Count(e => e.Id == id) > 0;
        }
    }
}