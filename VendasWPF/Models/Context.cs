using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendasWPF.Models
{
    class Context : DbContext
    {
        
        public DbSet<Cliente> Clientes { get; set; } //----------------------------------------------------------------------DbSet especifica que isso vai virar uma tabela no banco
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                                            Database=VendasWPFNoite;
                                                Trusted_Connection=true"); //--------------------------------------------- para fazer conexão com a base de dados
        }
    }
}
