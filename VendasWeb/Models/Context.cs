using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Models
{
    public class Context : IdentityDbContext<Usuario> // ----------------------------------------------------------------------------------------IdentityDbContext para conseguir trabalhar com autenticações que já vem prontas
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<UsuarioView> Usuarios { get; set; }
    }
}
