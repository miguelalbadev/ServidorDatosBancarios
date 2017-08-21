using ServidorDatosBancarios.Models;
using ServidorDatosBancarios.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorDatosBancarios.Service
{
    public class DomiciliosService : IDomiciliosService
    {
        private IDomiciliosRepository domiciliosRepository;

        public DomiciliosService(IDomiciliosRepository domiciliosRepository)
        {
            this.domiciliosRepository = domiciliosRepository;
        }

        public Domicilio Create(Domicilio domicilio)
        {
            return domiciliosRepository.Create(domicilio);
        }

        public Domicilio Read(long id)
        {
            return domiciliosRepository.Read(id);
        }

        public IQueryable<Domicilio> ReadAll()
        {
            IQueryable<Domicilio> domicilios;
            domicilios = domiciliosRepository.ReadAll();
            return domicilios;
        }

        public void Update(long id, Domicilio domicilio)
        {
            domiciliosRepository.Update(id, domicilio);
        }

        public Domicilio Delete(long id)
        {
            return domiciliosRepository.Delete(id);
        }
    }
}