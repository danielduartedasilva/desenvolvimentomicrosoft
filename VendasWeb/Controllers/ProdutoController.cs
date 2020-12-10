using System;
using System.Collections.Generic;
using System.IO;
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
    //[Authorize(Roles = "ADM")]
    [Authorize]
    public class ProdutoController : Controller
    {
        
        private readonly ProdutoDAO _produtoDAO; //-----------------------------------------------------------------------------------------------------readonly significa que o _contexto só pode receber alguma coisa no momento em que ele é declarado ou dentro do construtor
        private readonly CategoriaDAO _categoriaDAO;
        private readonly IWebHostEnvironment _hosting;
        public ProdutoController(ProdutoDAO produtoDAO, IWebHostEnvironment hosting, CategoriaDAO categoriaDAO)
        {// --------------------------------------------------------------------------------------------------------------tem uma propriedade que retorna o caminho da pasta wwwroot, retorna independente de onde a aplicação esteja fará o apontamento do caminho do wwwroot, da pasta images e do arquivo que chega com a extensão
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
            _hosting = hosting;
        }


        public IActionResult Index() //--------------------------------------------------------------------------------------------------------configuração para abrir o index do produto
        {
            //ViewBag.Produtos = _produtoDAO.Listar(); // ----------------------------------------------------------------------------------------- a requisição sai do controller e para a view, o banco é acessado na tabela de produtos e feito um select em todas as informações, isso é feito por um meio de transporte chamado ViewBag (meio de transporte, só vai servir para que as informações da action e mande para a view)
            ViewBag.Title = "Gerenciamento de Produtos";
            return View(_produtoDAO.Listar());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "Id", "Nome");
                return View();// ---------------------------------------------------------------------------------------------action que abre somente a página
        }
            [HttpPost] //-------------------------------------------------------------------------------------------------------------------------------só vai acessar quando a requisição for via post
        public IActionResult Cadastrar(Produto produto, IFormFile file)
        {//---------------------------------------------------------------------------------------------------------------actionque executa a ação do botão, recebendo os parâmetros com o mesmo nome dos inputs que demos na página de visualização, esse parametros foram resumidos para Produto produto, tem tambem o IFormFile file parametro de imagem
            if (ModelState.IsValid)
            {
                //produto.Categoria = _categoriaDAO.BuscarPorId(produto.CategoriaId);
                if (file != null)
                {
                    string arquivo = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";//----------------------------------Guid permite gerar um identificador único global, com caracteres alpha númericos que não se repetem{Guid.NewGuid()} é utilizado para trocar o nome da imagem, FileNome garante que vai ser obtido a informação correta de qualquer sistema operacional
                    string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);//-----------------------------combina pedaços para formar um caminho
                    file.CopyTo(new FileStream(caminho, FileMode.CreateNew));//----------------------------------------------cria um arquivo no pasta necessária
                    produto.Imagem = arquivo;//---------------------------------------------------------------------------salva o produto no banco e diz que está vinculado a esta imagem
                }
                else
                {
                    produto.Imagem = "semimagem.png";    
                }
				produto.Categoria = _categoriaDAO.BuscarPorId(produto.CategoriaId);
                if (_produtoDAO.Cadastrar(produto))
                {
                    return RedirectToAction("Index", "Produto"); //-----------------------------------------------------------------------------------------RedirectToAction redireciona para a action
                }
                ModelState.AddModelError("", "Já existe um produto com o mesmo nome !!"); // ----------------------------------------------------------------serve para adição de mensagens de erro
            }
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "Id", "Nome");
            return View(produto); //------------------------------------------------------------------------------------------------------------------------- quando a informação que vamos enviar pra view for do mesmo tipo da tipagem, é possível fazer desta forma (produto) 

        }
        public IActionResult Remover(int id)
        {
            _produtoDAO.Remover(id);            
            return RedirectToAction("Index", "Produto");
        }
        public IActionResult Alterar(int id)
        {
            return View(_produtoDAO.BuscarPorId(id));
        }
        public IActionResult Alterar(Produto produto)//-----------------------------------------------action que executa a ação do botão, recebendo os parâmetros com o mesmo nome dos inputs que demos na página de visualização
        {
            _produtoDAO.Alterar(produto);            
            return RedirectToAction("Index", "Produto"); //-----------------------------------------------------------------------------------------RedirectToAction redireciona para a action
        }

    }
}
