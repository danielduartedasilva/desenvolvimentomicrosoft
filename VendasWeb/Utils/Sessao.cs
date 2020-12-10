using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Utils
{
    public class Sessao
    {
        private readonly IHttpContextAccessor _http; //------------------------------------------------------------------vai permitir trabalhar com a sessão para que se consiga guardar a informação e dentro da sessão será guardado apenas o id do carrinho de compras
        public Sessao(IHttpContextAccessor http) => _http = http;
        private const string CARRINHO_ID = "CARRINHO_ID"; //-------------------------------------------------------------const constantes são colocadas com letras maiúsculas, CARRINHO_ID foi criado para guardar o nome da chave, para que não tenha possibilidade de confundir quando for chamar a informação
        
        public string BuscarCarrinhoId()
        {
            //-----------------------------------------------------------------------------------------------------------explicação do if abaixo: quando o método BuscarCarrinhoId for chamado, numa primeira vez, o _http.HttpContext.Session.GetString(CARRINHO_ID) vai estar nulo para aquele navegador, sendo assim uma sessão é criada, seto uma string que é o Guid vinculado a chave CARRINHO_ID, quando terminar o if ele busca o CARRINHO_ID agora com informação la dentro e não mais nulo, numa segunda vez que o método for buscado ao perguntar para o if não será mais nulo e retorna o else
            if (_http.HttpContext.Session.GetString(CARRINHO_ID) == null)
            {
                _http.HttpContext.Session.SetString(CARRINHO_ID, Guid.NewGuid().ToString());

            }
            return _http.HttpContext.Session.GetString(CARRINHO_ID);
        }
    }
}
