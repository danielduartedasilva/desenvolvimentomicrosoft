using System;
using System.Collections.Generic;
using System.Text;
using VendasConsole.DAL;
using VendasConsole.Models;

namespace VendasConsole.Views
{
    class ListarVendas
    {
        public static void Renderizar(List<Venda> vendas)
        {
            double totalGeral = 0, totalVenda = 0, totalItem = 0;
            Console.WriteLine(" ---- LISTAR VENDAS ----\n ");
            foreach (Venda vendaCadastrada in vendas)
            {
                totalVenda = 0;
                Console.WriteLine($"Cliente: {vendaCadastrada.Cliente.Nome}");
                Console.WriteLine($"Funcionário: {vendaCadastrada.Funcionario.Nome}");
                Console.WriteLine("\n ---- ITENS DA VENDA ---- \n");

                foreach (ItemVenda itemCadastrado in vendaCadastrada.Itens)
                {
                    Console.WriteLine($"\t{itemCadastrado.Produto.Nome}");//\t para fazer uma tabulação
                    totalItem = itemCadastrado.Produto.Preco * itemCadastrado.Quantidade;
                    Console.WriteLine($"\t{itemCadastrado.Produto.Preco:C2} x " +
                        $"{itemCadastrado.Quantidade} = {totalItem:C2}");
                    totalVenda += totalItem;
                    
                }
                Console.WriteLine($"\n\tTotal da venda: {totalVenda:C2}\n");
                totalGeral += totalVenda;
            }
            Console.WriteLine($"Total geral: {totalGeral:C2}");
        }
    }
}
