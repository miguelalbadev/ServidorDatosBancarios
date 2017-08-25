using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServidorDatosBancarios.Models;
using ServidorDatosBancarios.Excepciones;
using System.Data.Entity;

namespace ServidorDatosBancarios.Repository {
    public class CuentasBancariasRepository : ICuentasBancariasRepository {

        public CuentaBancaria Create(CuentaBancaria cuentaBancaria) {
            return ApplicationDbContext.applicationDbContext.CuentasBancarias.Add(cuentaBancaria);
        }

        public CuentaBancaria Delete(long id) {
            CuentaBancaria cuentaBancaria = ApplicationDbContext.applicationDbContext.CuentasBancarias.Find(id);
            if (cuentaBancaria == null) {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.CuentasBancarias.Remove(cuentaBancaria);
            return cuentaBancaria;
        }

        public CuentaBancaria Read(long id) {
            return ApplicationDbContext.applicationDbContext.CuentasBancarias.Find(id);
        }

        public IQueryable<CuentaBancaria> ReadAll() {
            IList<CuentaBancaria> lista = new List<CuentaBancaria>(ApplicationDbContext.applicationDbContext.CuentasBancarias);
            return lista.AsQueryable();
        }

        public void Update(long id, CuentaBancaria cuentaBancaria) {
            if (ApplicationDbContext.applicationDbContext.CuentasBancarias.Count(e => e.Id == cuentaBancaria.Id) == 0) {
                throw new NoEncontradoException("No he encontrado la entidad ");
            }
            ApplicationDbContext.applicationDbContext.Entry(cuentaBancaria).State = EntityState.Modified;
        }
    }
}