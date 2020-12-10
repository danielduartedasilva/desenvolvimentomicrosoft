using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendasWeb.DAL;
using VendasWeb.Models;
using VendasWeb.Utils;

namespace VendasWeb.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly ItemVendaDAO _itemVendaDAO;
        private readonly Sessao _sessao;

        public HomeController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO, ItemVendaDAO itemVendaDAO, Sessao sessao)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _itemVendaDAO = itemVendaDAO;
            _sessao = sessao;
    }
    public IActionResult Index(int id)
        {
            ViewBag.Categorias = _categoriaDAO.Listar();
            //o if abaixo foi substituido pelo por este if ternário
            List<Produto> produtos = id == 0 ? _produtoDAO.Listar() : _produtoDAO.ListarPorCategoria(id);//-------------- os : funcionam como um else, tanto o if quanto o else tem que ser do mesmo tipo
            return View(produtos);
            //if (id == 0)
            //{                
            //    return View(_produtoDAO.Listar());
            //}
            //return View(_produtoDAO.ListarPorCategoria(id));
        }
        public IActionResult AdicionarAoCarrinho(int id)
        {
            Produto produto = _produtoDAO.BuscarPorId(id);
            ItemVenda item = new ItemVenda
            {
                Produto = produto,
                Preco = produto.Preco,
                Quantidade = 1,
                CarrinhoId = _sessao.BuscarCarrinhoId()
            };
            _itemVendaDAO.Cadastrar(item);
            return RedirectToAction("CarrinhoCompras");
        }
        public IActionResult CarrinhoCompras()
        {
            string carrinhoId = _sessao.BuscarCarrinhoId();
            return View(_itemVendaDAO.ListarPorCarrinhoId(carrinhoId));
        }
    }

}
