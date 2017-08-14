//using FCamara.Comum;
//using FCamara.Servicos.Contratos;
//using FCamara.Servicos.Contratos.Impl;
//using FluentAssertions;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;

//namespace FCamara.ServicoAutenticacao.Testes
//{
//    [TestClass]
//    public class ServicoTokenTestesUnitario
//    {
//        private IServicoToken servicoToken;
//        private Mock<ITokenProvider> tokenProvider;

//        [TestInitialize]
//        public void Initialize()
//        {
//            tokenProvider = new Mock<ITokenProvider>();
//            tokenProvider.Setup(x => x.ArmazenarToken(It.IsAny<Guid>(), It.IsAny<DateTime>()));

//            tokenProvider.Setup(x => x.EhValido(It.IsAny<Guid>()))
//                         .Returns(true);
            
//            servicoToken = new ServicoToken(tokenProvider.Object);            
//        }

//        [TestCleanup]
//        public void Cleanup()
//        {
//            servicoToken = null;
//        }
        
//        [TestMethod]
//        public void GerarToken_ComSucesso()
//        {
//            var token = servicoToken.GerarToken();
//            token.Should().NotBeNull();
//            token.DataExpiracao.Should().BeAfter(DateTime.Now);
//        }

//        [TestMethod]
//        public void ValidarToken_ComSucesso()
//        {
//            var token = servicoToken.GerarToken();
//            servicoToken.TokenValido(token.Token).Should().BeTrue();
//        }

//        [TestMethod]
//        public void ValidarToken_TokenExpirado_ComSucesso()
//        {
//            tokenProvider.Setup(x => x.EhValido(It.IsAny<Guid>()))
//                         .Returns(false);

//            var token = servicoToken.GerarToken();
//            servicoToken.TokenValido(token.Token).Should().BeFalse();
//        }        

//        [TestMethod]
//        public void a()
//        {
//            var a = System.IO.Path.GetTempPath();



//        }
//    }
//}
