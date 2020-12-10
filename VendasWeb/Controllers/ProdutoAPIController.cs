using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasWeb.DAL;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    [Route("api/Produto")]//para a apresentação é só dizer quais são as rotas e o que elas estão fazendo
    [ApiController]
    public class ProdutoAPIController : ControllerBase
    {
        private readonly ProdutoDAO _produtoDAO; //-----------------------------------------------------------------------------------------------------readonly significa que o _contexto só pode receber alguma coisa no momento em que ele é declarado ou dentro do construtor       
        
        public ProdutoAPIController(ProdutoDAO produtoDAO)
        {// ------------------------------------------------------------------------------------------------------------------------tem uma propriedade que retorna o caminho da pasta wwwroot, retorna independente de onde a aplicação esteja fará o apontamento do caminho do wwwroot, da pasta images e do arquivo que chega com a extensão
            _produtoDAO = produtoDAO;
            
        }
        
        //GET: /api/Produto/Listar
        [HttpGet]//---------------------------------------------------------------------------------------------------------------se precisar chamar o Listar e não usar a requisição via GET não chega
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<Produto> produtos = _produtoDAO.Listar();
            if (produtos.Count > 0)
            {
                return Ok(produtos); //----------------------------------------------------------------------------------------------- o Ok é o código 200
            }
            return BadRequest(new {msg= "Lista de produtos vazia!"}); //--------------------------------------------------------------------------------------------------- o BadRequest é o código 400
        }

        //GET: /api/Produto/Buscar/1
        [HttpGet]//---------------------------------------------------------------------------------------------------------------se precisar chamar o Listar e não usar a requisição via GET não chega
        [Route("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            Produto produto = _produtoDAO.BuscarPorId(id);
            if (produto != null)
            {
                return Ok(produto); //----------------------------------------------------------------------------------------------- o Ok é o código 200
            }
            return NotFound(new { msg = "Produto não encontrado!" }); //--------------------------------------------------------------------------------------------------- o BadRequest é o código 400, este recupera da url
        }

        //POST: /api/Produto/Cadastrar
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (_produtoDAO.Cadastrar(produto))
                {
                    return Created("", produto);
                }
                return Conflict(new { msg = "Esse produto já existe!" });
            }
            return BadRequest(ModelState);
        }
    }
}
