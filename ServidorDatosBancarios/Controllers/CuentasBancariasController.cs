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
    public class CuentasBancariasController : ApiController
    {
        

        private ICuentasBancariasService cuentasBancariasService;

        public CuentasBancariasController(ICuentasBancariasService _cuentasBancariasService) {
            this.cuentasBancariasService = _cuentasBancariasService;
        }



        // GET: api/CuentasBancarias
        public IQueryable<CuentaBancaria> GetCuentasBancarias()
        {
            return cuentasBancariasService.ReadAll();
        }

        // GET: api/CuentasBancarias/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult GetCuentaBancaria(long id)
        {
            CuentaBancaria cuentaBancaria = cuentasBancariasService.Read(id);
            if (cuentaBancaria == null)
            {
                return NotFound();
            }

            return Ok(cuentaBancaria);
        }

        // PUT: api/CuentasBancarias/5
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
            
            try
            {
                cuentasBancariasService.Update(cuentaBancaria);
            }
            catch (Exception e)
            {
                throw new NoEncontradoException("Ocurrio un error en el método PUT ", e.InnerException);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CuentasBancarias
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult PostCuentaBancaria(CuentaBancaria cuentaBancaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cuentaBancaria = cuentasBancariasService.Create(cuentaBancaria);
                       
            return CreatedAtRoute("DefaultApi", new { id = cuentaBancaria.Id }, cuentaBancaria);
        }

        // DELETE: api/CuentasBancarias/5
        [ResponseType(typeof(CuentaBancaria))]
        public IHttpActionResult DeleteCuentaBancaria(long id)
        {
            CuentaBancaria cuentaBancaria;
            try {
                cuentaBancaria = cuentasBancariasService.Delete(id);
            }
            catch (Exception e) {
                throw new NoEncontradoException("Ocurrió un error durante el método DELETE ", e.InnerException);
            }
            return Ok(cuentaBancaria);
        }

        
    }
}