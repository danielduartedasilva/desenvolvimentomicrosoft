using System;
using System.Collections.Generic;
using System.Text;
using VendasConsole.Models;

namespace VendasConsole.DAL
{
    class FuncionarioDAO
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();
        public static List<Funcionario> Listar() => funcionarios;

        public static bool Cadastrar(Funcionario f)
        {
            if (BuscarFuncionario(f.Cpf) == null)
            {
                funcionarios.Add(f);
                return true;
            }
            return false;
        }
            public static Funcionario BuscarFuncionario(string cpf)
        {
            foreach (Funcionario funcionarioCadastrado in funcionarios)
            {
                if (funcionarioCadastrado.Cpf == cpf)
                {
                    return funcionarioCadastrado;
                }

            }
            return null;
        }

    }
}
