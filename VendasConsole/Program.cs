using System;

namespace VendasConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();//-----------------------------------------------------------------------------------------faz a limpeza do console
                Console.WriteLine(" ----- APLICAÇÃO DE VENDAS -----\n ");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Listar cliente");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("\nDigite a opção desejada: ");
                opcao = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine(" ----- CADASTRAR CLIENTE -----\n ");
                        break;
                    case 2:
                        Console.WriteLine(" ---- LISTAR CLIENTES ----\n ");
                        break;
                    case 0:
                        Console.WriteLine(" ---- SAINDO ----\n ");
                        break;
                    default:
                        Console.WriteLine(" ---- OPÇÃO INVÁLIDA ----\n ");
                        break;
                }
                Console.WriteLine("\nPressione uma tecla par continuar..... ");
                Console.ReadKey();//---------------------------------------------------------------------------------------comando que pede para o usuário pedir uma tecla para continuar
            } while (opcao != 0);
        }
    }
}
