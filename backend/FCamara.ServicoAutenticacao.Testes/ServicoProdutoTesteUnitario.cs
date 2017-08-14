using FCamara.Dominio;
using FCamara.Dominio.Repositorios;
using FCamara.Servicos.Contratos;
using FCamara.Servicos.Contratos.Impl;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FCamara.ServicoAutenticacao.Testes
{
    [TestClass]
    public class ServicoProdutoTesteUnitario
    {
        private Mock<IRepositorio<Produto>> repositorioProduto;
        private IServicoProduto servicoProduto;


        [TestInitialize]
        public void Initialize()
        {
            repositorioProduto = new Mock<IRepositorio<Produto>>();
            repositorioProduto.Setup(x => x.Listar()).Returns(new List<Produto>() { new Produto("Produto Teste", "Descrição Produto", 1) });
            
            servicoProduto = new ServicoProduto(repositorioProduto.Object);
        }

        [TestMethod]
        public void ServicoProduto_ListarProdutos_ComSucesso()
        {
            var produtos = servicoProduto.ListarProdutos();

            produtos.Should().HaveCount(1);
            produtos.FirstOrDefault().Nome.Should().Be("Produto Teste");
        }        
    }
}
