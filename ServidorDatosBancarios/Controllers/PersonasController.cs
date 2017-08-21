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
using ServidorDatosBancarios.Service;
using ServidorDatosBancarios.Excepciones;
using System.Web.Http.Cors;

namespace ServidorDatosBancarios.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonasController : ApiController
    {
        public IPersonasService personasService;
        public PersonasController(IPersonasService personasService)
        {
            this.personasService = personasService;
        }

        // POST: api/Personas
        [ResponseType(typeof(Persona))]
        public IHttpActionResult PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            persona = personasService.Create(persona);
            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // GET: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult GetPersona(long id)
        {
            Persona persona = personasService.Read(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // GET: api/Personas
        public IQueryable<Persona> GetPersonas()
        {
            return personasService.ReadAll();
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersona(long id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
            {
                return BadRequest();
            }

            try
            {
                personasService.Update(id, persona);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult DeletePersona(long id)
        {
            Persona persona;

            try
            {
                persona = personasService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }
            return Ok(persona);
        }
    }
}