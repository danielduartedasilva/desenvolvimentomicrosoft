using System;
using System.Collections.Generic;
using System.Text;
using VendasConsole.DAL;
using VendasConsole.Models;
using VendasConsole.Utils;

namespace VendasConsole.Views
{
    class CadastrarFuncionario
    {
        public static void Renderizar()
        {
            Funcionario f = new Funcionario();
            Console.WriteLine(" ----- CADASTRAR FUNCIONÁRIO -----\n ");
            Console.WriteLine("Digite o nome do funcionário:\n");
            f.Nome = Console.ReadLine();
            Console.WriteLine("Digite o cpf do funcionário:\n");
            f.Cpf = Console.ReadLine();
            if (Validacao.ValidarCpf(f.Cpf))
            {
                if (FuncionarioDAO.Cadastrar(f))
                {
                    Console.WriteLine("Funcionário cadastrado com sucesso !");
                }
                else
                {
                    Console.WriteLine("Esse funcionário já existe !");
                }
            }
            else
            {
                Console.WriteLine("CPF inválido !");
            }
        }
        
    }
}
