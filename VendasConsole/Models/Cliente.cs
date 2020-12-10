﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VendasConsole.Models
{
    class Cliente
    {
        //Contrutor
        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
        public Cliente()
        {
            CriadoEm = DateTime.Now;      
        }
        //Atributos, propriedades e características
        public string Nome { get; set; } //--------------------------------------------------------------------------------- o public é para o get e set e não para o atributo
        public string Cpf { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome} | CPF: {Cpf} | Criado em: {CriadoEm}";
        }
    }
}
