using System;
using System.Collections.Generic;
using System.Text;
using VendasConsole.Models;

namespace VendasConsole.DAL
{
    class Dados
    {
        public static void Inicializar()
        {
            Cliente cliente = new Cliente
            {
                Nome = "Daniel Duarte",
                Cpf = "00601692900"
            };
            Funcionario funcionario = new Funcionario
            {
                Nome = "Maria Nazaré",
                Cpf = "00601692900"
            };
            Produto produto = new Produto
            {
                Nome = "Bolacha",
                Preco = 3.75,
                Quantidade = 150
            };
            ClienteDAO.Cadastrar(cliente);
            FuncionarioDAO.Cadastrar(funcionario);
            ProdutoDAO.Cadastrar(produto);

        }
    }
}
