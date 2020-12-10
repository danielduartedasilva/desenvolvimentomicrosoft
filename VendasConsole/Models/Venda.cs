using System;
using System.Collections.Generic;
using System.Text;

namespace VendasConsole.Models
{
    class Venda
    {
        public Venda()
        {
            CriadoEm = DateTime.Now;
            Cliente = new Cliente();
            Funcionario = new Funcionario();
            Itens = new List<ItemVenda>();
        }
        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public List<ItemVenda> Itens { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
