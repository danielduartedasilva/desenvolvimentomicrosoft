using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VendasWeb.DAL;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly CategoriaDAO _categoriaDAO;
        private readonly ProdutoDAO _produtoDAO;
        private readonly IWebHostEnvironment _hosting;

        public CategoriaController(ProdutoDAO produtoDAO, IWebHostEnvironment hosting, CategoriaDAO categoriaDAO)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _hosting = hosting;
        }
        public IActionResult Index()
        {

            ViewBag.Title = "Gerenciamento de Categorias";
            return View(_categoriaDAO.Listar());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "Id", "Nome");
            return View();// ---------------------------------------------------------------------------------------------action que abre somente a página
        }

        public IActionResult Cadastrar(Categoria categoria, IFormFile file)
        {//---------------------------------------------------------------------------------------------------------------actionque executa a ação do botão, recebendo os parâmetros com o mesmo nome dos inputs que demos na página de visualização, esse parametros foram resumidos para Produto produto, tem tambem o IFormFile file parametro de imagem
            if (ModelState.IsValid)
            {
                if (_categoriaDAO.Cadastrar(categoria))
                {
                    return RedirectToAction("Index", "Categoria"); //-----------------------------------------------------------------------------------------RedirectToAction redireciona para a action
                }
                ModelState.AddModelError("", "Já existe uma categoria com o mesmo nome !!"); // ----------------------------------------------------------------serve para adição de mensagens de erro
            }
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "Id", "Nome");
            return View(categoria); //------------------------------------------------------------------------------------------------------------------------- quando a informação que vamos enviar pra view for do mesmo tipo da tipagem, é possível fazer desta forma (produto) 

        }
    }
}
