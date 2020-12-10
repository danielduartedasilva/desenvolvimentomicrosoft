using System;
using System.Collections.Generic;
using System.Text;
using VendasConsole.DAL;
using VendasConsole.Models;

namespace VendasConsole.Views
{
    class CadastrarVenda
    {
        public static void Renderizar()
        {
            Venda venda = new Venda();
            Cliente c = new Cliente();
            Funcionario f = new Funcionario();
            Produto p = new Produto();
            ItemVenda iv = new ItemVenda();

            Console.WriteLine(" ----- CADASTRAR VENDA -----\n ");
            Console.WriteLine("Digite o CPF do cliente: ");
            //Cliente
            c.Cpf = Console.ReadLine();
            c = ClienteDAO.BuscarCliente(c.Cpf);
            if (c != null)
            {
                venda.Cliente = c;
                //Funcionário
                Console.WriteLine("Digite o CPF do funcionário: ");
                f.Cpf = Console.ReadLine();
                f = FuncionarioDAO.BuscarFuncionario(f.Cpf);
                if (f != null)
                {
                    venda.Funcionario = f;
                    do
                    {
                        iv = new ItemVenda();
                        p = new Produto();
                        Console.Clear();
                        Console.WriteLine(" ----- ADICIONAR PRODUTO -----\n ");
                        Console.WriteLine("Digite o nome do produto: ");
                        p.Nome = Console.ReadLine();
                        p = ProdutoDAO.BuscarProduto(p.Nome);
                        if (p != null)
                        {
                            iv.Produto = p;
                            Console.WriteLine("Digite a quantidade do produto: ");
                            iv.Quantidade = Convert.ToInt32(Console.ReadLine());
                            iv.Preco = p.Preco;
                            venda.Itens.Add(iv);
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado!");
                        }
                        Console.WriteLine("\nDeseja adicionar mais produtos ? (S/N)");
                    } while (Console.ReadLine().ToUpper().Equals("S"));
                    //Cadastrar venda
                    VendaDAO.Cadastrar(venda);
                    Console.WriteLine("Venda cadastrada com sucesso !! ");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado!");
                }
            }
        }
    }
}
