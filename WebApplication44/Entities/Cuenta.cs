using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication44.Entities
{
    public class Cuenta
    {
        [Key]
        public int  AccountNumber { get; set; }
        public string TipoMoneda { get; set; }
        public int Saldo { get; set; }
        public string Status1 { get; set; }
        public int AccountType { get; set; }
        public int ClientNumber { get; set; }

    }
}
