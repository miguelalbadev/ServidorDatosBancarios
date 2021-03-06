﻿using ServidorDatosBancarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorDatosBancarios.Repository
{
    public interface IDomiciliosRepository
    {
        Domicilio Create(Domicilio domicilio);
        Domicilio Read(long Id);
        IQueryable<Domicilio> ReadAll();
        void Update(long id, Domicilio domicilio);
        Domicilio Delete(long id);
    }
}
