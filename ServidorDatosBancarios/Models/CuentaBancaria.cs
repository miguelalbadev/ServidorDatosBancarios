using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServidorDatosBancarios.Models {
    public class CuentaBancaria {
        [Key]
        public long Id { get; set; }
        public string NombreEntidad { get; set; }
        public float Saldo { get; set; }
        public string CCC { get; set; }
    }
}