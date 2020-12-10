using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VendasWPF.Models
{
    [Table("Vendedores")]
    class Vendedor : Pessoa
    {
        public double Salario { get; set; }
    }
}
