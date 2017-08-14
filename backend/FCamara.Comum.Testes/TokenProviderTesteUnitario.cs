using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;

namespace FCamara.Comum.Testes
{
    [TestClass]
    public class TokenProviderTesteUnitario
    {
        private ITokenProvider tokenProvider;

        [TestInitialize]
        public void Initialize()
        {
            tokenProvider = new TokenProvider();
        }

        [TestCleanup]
        public void Cleanup()
        {
            tokenProvider = null;

            File.Delete(ConfigurationManager.AppSettings["ArquivoToken"]);
        }

        [TestMethod]
        public void ArmazenarToken_DadosValidos_ComSucesso()
        {
            var token = Guid.NewGuid();
            var dataExpiracao = DateTime.Now.AddMinutes(1);
            tokenProvider.ArmazenarToken(token, dataExpiracao);
            tokenProvider.EhValido(token).Should().BeTrue();
        }

        [TestMethod]
        public void ArmazenarToken_TokenInvalido_DeveExibirCritica()
        {
            var token = Guid.Empty;
            var dataExpiracao = DateTime.Now.AddMinutes(1);
            
            Action act = () => tokenProvider.ArmazenarToken(token, dataExpiracao);
            act.ShouldThrow<ArgumentException>().And.Message.Contains("Token inválido");
        }

        [TestMethod]
        public void ArmazenarToken_DataExpiracaoInvalida_DeveExibirCritica()
        {
            var token = Guid.Empty;
            var dataExpiracao = DateTime.Now.AddMinutes(-10);

            Action act = () => tokenProvider.ArmazenarToken(token, dataExpiracao);
            act.ShouldThrow<ArgumentException>().And.Message.Contains("Data Expiração inválida");
        }

        [TestMethod]
        public void EhValido_TokenValidoNaoExpirado_ComSucesso()
        {
            var token = Guid.NewGuid();
            var dataExpiracao = DateTime.Now.AddMinutes(1);

            tokenProvider.ArmazenarToken(token, dataExpiracao);
            tokenProvider.EhValido(token).Should().BeTrue();
        }

        [TestMethod]
        public void EhValido_TokenNaoArmazenado_DeveExibirCritica()
        {
            var token = Guid.NewGuid();
            
            Action act = () => tokenProvider.EhValido(token);
            act.ShouldThrow<ArgumentException>().And.Message.Contains("Token não encontrado");
        }

        [TestMethod]
        public void EhValido_TokenExpirado_DeveExibirCritica()
        {
            var token = Guid.NewGuid();

            Action act = () => tokenProvider.EhValido(token);
            act.ShouldThrow<ArgumentException>().And.Message.Contains("Token expirado");
        }

    }
}
