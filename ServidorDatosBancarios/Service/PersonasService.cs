using ServidorDatosBancarios.Models;
using ServidorDatosBancarios.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorDatosBancarios.Service
{
    public class PersonasService : IPersonasService
    {
        private IPersonasRepository personasRepository;
        public PersonasService(IPersonasRepository personasRepository)
        {
            this.personasRepository = personasRepository;
        }

        public Persona Create(Persona persona)
        {
            return personasRepository.Create(persona);
        }

        public Persona Read(long id)
        {
            return personasRepository.Read(id);
        }

        public IQueryable<Persona> ReadAll()
        {
            IQueryable<Persona> personas;
            personas = personasRepository.ReadAll();
            return personas;
        }

        public void Update(long id, Persona persona)
        {
            personasRepository.Update(id, persona);
        }

        public Persona Delete(long id)
        {
            //Personas persona = personasRepository.Read(id);
            return personasRepository.Delete(id);
        }
    }
}