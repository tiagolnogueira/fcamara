using System.Collections.Generic;
using System.Linq;
using FCamara.Dominio.Repositorios;
using FCamara.Dominio;
using FCamara.Servicos.Contratos.Dto;

namespace FCamara.Servicos.Contratos.Impl
{
    public class ServicoProduto : IServicoProduto
    {
        private readonly IRepositorio<Produto> _repositorioProduto;

        public ServicoProduto(IRepositorio<Produto> repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public IList<ProdutoDto> ListarProdutos()
        {
            var produtos = _repositorioProduto.Listar();

            return produtos
                    .Select(x => new ProdutoDto()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Descricao = x.Descricao,
                        Preco = x.Preco
                    })
                    .ToList();
        }
    }
}
