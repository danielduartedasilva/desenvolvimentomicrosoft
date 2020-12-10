using System;
using System.Collections.Generic;
using System.Text;

namespace VendasConsole.Models
{
    class Funcionario
    {
        public Funcionario(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
        public Funcionario()
        {
            CriadoEm = DateTime.Now;
        }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome} | Cpf: {Cpf} | CriadoEm: {CriadoEm}";
        }

    }
}
