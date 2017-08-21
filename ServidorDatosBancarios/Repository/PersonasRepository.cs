using ServidorDatosBancarios.Excepciones;
using ServidorDatosBancarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorDatosBancarios.Repository
{
    public class PersonasRepository
    {
        public Persona Create(Persona persona)
        {
            return ApplicationDbContext.applicationDbContext.Personas.Add(persona);
        }

        public Persona Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Personas.Find(id);
        }

        public IQueryable<Persona> ReadAll()
        {
            IList<Persona> personas = new List<Persona>(ApplicationDbContext.applicationDbContext.Personas);
            return personas.AsQueryable();
        }

        public void Update(long id, Persona persona)
        {
            if (ApplicationDbContext.applicationDbContext.Personas.Count(e => e.Id == persona.Id) == 0)
            {
                throw new NoEncontradoException("No se ha encontrado la entidad.");
            }
        }

        public Persona Delete(long id)
        {
            Persona persona = ApplicationDbContext.applicationDbContext.Personas.Find(id);
            if (persona == null)
            {
                throw new NoEncontradoException("No se ha encontrado la entidad.");
            }
            ApplicationDbContext.applicationDbContext.Personas.Remove(persona);
            return persona;
        }
    }
}