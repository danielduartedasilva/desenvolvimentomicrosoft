using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;

namespace VendasWeb.DAL
{
    public class ProdutoDAO
    {
        private readonly Context _context; //-------------------------------------------------------------------------------------------------------------------------OBJETO glogal de contexto, readonly significa que o _contexto só pode receber alguma coisa no momento em que ele é declarado ou dentro do construtor
        public ProdutoDAO(Context context) => _context = context;//----------------------------------------------------------------------------------------------------Construtor, que passo o que chega como parâmetro para o nosso contexto glogal
        public List<Produto> Listar() => _context.Produtos.Include(x => x.Categoria).ToList();//--------------------------------------------------------------------------------------------------Método que lista TODOS os produtos
        public Produto BuscarPorId(int id) => _context.Produtos.Find(id);
        public Produto BuscarPorNome(string nome) =>
            _context.Produtos.FirstOrDefault(x => x.Nome == nome); //-------------------------------------------------------------------------------------------------- pega o primeiro que encontrar, se não entrantrar devolve nulo, x vai na tabela na linha do nome e compara
        
        public List<Produto> ListarPorCategoria(int id) =>
        
            _context.Produtos.Where(x => x.CategoriaId == id).ToList();//--------------------------------------------------------------------------------------------o x é uma expressão lambda, para unir dados de tabelas do banco 
        
        
        public bool Cadastrar(Produto produto)
        {
            if (BuscarPorNome(produto.Nome) == null)
            {            
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Remover(int id)
        {
            _context.Produtos.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }
    }
}
