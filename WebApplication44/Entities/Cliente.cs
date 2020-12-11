using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Cliente
    {
        [Key]
        public int ClientNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string lastName1 { get; set; }
        public string lastName2 { get; set; }
        public DateTime BirthDate { get; set; }
        public int Identity1 { get; set; }
        public string Gender { get; set; }
        public string BirthdatePlace { get; set; }
    }
}
