using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServidorDatosBancarios.Models {
    public class Domicilio {

        [Key]
        public long Id { get; set; }
        public string Calle { get; set;}
        public string Localidad { get; set; }
        public string Provincia { get; set;}
        public string Telefono { get; set; }
    }
}