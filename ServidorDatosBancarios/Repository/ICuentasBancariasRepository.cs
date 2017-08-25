using ServidorDatosBancarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorDatosBancarios.Repository {
    public interface ICuentasBancariasRepository {

        CuentaBancaria Read(long id);
        IQueryable<CuentaBancaria> ReadAll();
        CuentaBancaria Create(CuentaBancaria cuentaBancaria);
        void Update(long id, CuentaBancaria cuentaBancaria);
        CuentaBancaria Delete(long id);
    }
}
