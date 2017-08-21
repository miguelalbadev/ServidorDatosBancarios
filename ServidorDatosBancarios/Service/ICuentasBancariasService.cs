﻿using ServidorDatosBancarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorDatosBancarios.Service {
    public interface ICuentasBancariasService {

        CuentaBancaria Read(long id);
        IQueryable<CuentaBancaria> ReadAll();
        CuentaBancaria Create(CuentaBancaria cuentaBancaria);
        void Update(CuentaBancaria cuentaBancaria);
        CuentaBancaria Delete(long id);
    }
}