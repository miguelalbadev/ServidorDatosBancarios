using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServidorDatosBancarios.Models;
using ServidorDatosBancarios.Repository;

namespace ServidorDatosBancarios.Service {
    public class CuentasBancariasService : ICuentasBancariasService {

        private ICuentasBancariasRepository cuentasBancariasRepository;

        public CuentasBancariasService(ICuentasBancariasRepository _cuentasBancariasRepository) {
            this.cuentasBancariasRepository = _cuentasBancariasRepository;
        }
        public CuentaBancaria Create(CuentaBancaria cuentaBancaria) {
            return cuentasBancariasRepository.Create(cuentaBancaria);
        }

        public CuentaBancaria Delete(long id) {
            return cuentasBancariasRepository.Delete(id);
        }

        public CuentaBancaria Read(long id) {
            return cuentasBancariasRepository.Read(id);
        }

        public IQueryable<CuentaBancaria> ReadAll() {
            return cuentasBancariasRepository.ReadAll();
        }

        public void Update(long id, CuentaBancaria cuentaBancaria) {
            cuentasBancariasRepository.Update(id, cuentaBancaria);
        }
    }
}