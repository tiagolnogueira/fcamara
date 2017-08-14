using FCamara.Servicos.Contratos;
using FCamara.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FCamara.WebApi.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IServicoProduto _servicoProduto;

        public ProdutoController(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        [Autenticacao]
        [HttpGet]
        [Route("api/v1/produtos")]
        public IHttpActionResult Listar()
        {
            var produtos = _servicoProduto.ListarProdutos();
            return Ok(produtos);                  
        }
    }
}
