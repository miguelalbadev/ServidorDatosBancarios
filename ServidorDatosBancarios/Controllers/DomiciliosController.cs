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
using System.Web.Http.Cors;
using ServidorDatosBancarios.Service;
using ServidorDatosBancarios.Excepciones;

namespace ServidorDatosBancarios.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DomiciliosController : ApiController
    {
        public IDomiciliosService domiciliosService;
        public DomiciliosController(IDomiciliosService domiciliosService)
        {
            this.domiciliosService = domiciliosService;
        }

        // POST: api/Domicilios
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult PostDomicilio(Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            domicilio = domiciliosService.Create(domicilio);
            return CreatedAtRoute("DefaultApi", new { id = domicilio.Id }, domicilio);
        }

        // GET: api/Domicilios/5
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult GetDomicilio(long id)
        {
            Domicilio domicilio = domiciliosService.Read(id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return Ok(domicilio);
        }

        // GET: api/Domicilios
        public IQueryable<Domicilio> GetDomicilios()
        {
            return domiciliosService.ReadAll();
        }

        // PUT: api/Domicilios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDomicilio(long id, Domicilio domicilio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != domicilio.Id)
            {
                return BadRequest();
            }

            try
            {
                domiciliosService.Update(id, domicilio);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Domicilios/5
        [ResponseType(typeof(Domicilio))]
        public IHttpActionResult DeleteDomicilio(long id)
        {
            Domicilio domicilio;

            try
            {
                domicilio = domiciliosService.Delete(id);
            } catch(NoEncontradoException) {
                return NotFound();
            }
            return Ok(domicilio);
        }
    }
}