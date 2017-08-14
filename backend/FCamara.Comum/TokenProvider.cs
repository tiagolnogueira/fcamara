using System;
using System.Configuration;
using System.IO;

namespace FCamara.Comum
{
    public class TokenProvider : ITokenProvider
    {
        public TokenProvider()
        {
            if (!File.Exists(ArquivoToken)) { File.WriteAllText(ArquivoToken, string.Empty); }
        }

        public string ArquivoToken
        {
            get { return Path.Combine(Path.GetTempPath(), ConfigurationManager.AppSettings["ArquivoToken"]); }
        }
        
        public void ArmazenarToken(Guid token, DateTime dataExpiracao)
        {
            if (token == Guid.Empty)
                throw new ArgumentException("Token inválido.");

            if (dataExpiracao < DateTime.Now)
                throw new ArgumentException("Data Expiração inválida.");
            
            File.WriteAllText(ArquivoToken, $"{token.ToString()};{dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss")}");            
        }

        public bool EhValido(Guid token)
        {
            var conteudo = File.ReadAllText(ArquivoToken).Split(';');

            if (conteudo == null)
                throw new ArgumentNullException("Não autenticado.");

            var tokenEncontrado = Guid.Parse(conteudo[0]) == token;

            if (!tokenEncontrado)
                throw new ArgumentException("Token não encontrado.");

            var tokenNaoExpirou = DateTime.Now <= DateTime.Parse(conteudo[1]);

            return tokenEncontrado && tokenNaoExpirou;
        }
    }
}
