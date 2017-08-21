using ServidorDatosBancarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorDatosBancarios.Repository {
    public interface IPersonasRepository {
        Persona Create(Persona persona);
        Persona Read(long id);
        IQueryable<Persona> ReadAll();
        void Update(long id, Persona persona);
        Persona Delete(long id);
    }
}
