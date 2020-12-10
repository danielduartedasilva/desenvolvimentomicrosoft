using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VendasWPF.Models
{
    [Table("Clientes")]
    class Cliente : Pessoa
    {
        public string Email { get; set; }
        //public override string ToString() => $"{Id} - {Nome}";
        
    }
}
