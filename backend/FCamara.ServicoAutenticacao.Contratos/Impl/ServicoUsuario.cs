using FCamara.ServicoAutenticacao.Contratos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCamara.ServicoAutenticacao.Contratos.Dto;
using FCamara.Dominio.Repositorios;
using FCamara.Dominio;

namespace FCamara.ServicoAutenticacao.Contratos.Impl
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IRepositorio<Usuario> _repositorioUsuario;

        public ServicoUsuario(IRepositorio<Usuario> repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void ArmazenarToken(int id, string token, DateTime dataExpiracao)
        {
            var usuario = _repositorioUsuario.Obter(id);

            usuario.DataExpiracao = dataExpiracao;
            usuario.Token = token;

            var retorno = _repositorioUsuario.Persistir();
        }

        public UsuarioDto Login(string login, string senha)
        {
            var usuario = _repositorioUsuario.Listar().FirstOrDefault(x => x.Login == login && x.Senha == senha);

            if (usuario != null)
                return new UsuarioDto()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Login = usuario.Login
                };

            return null;            
        }        
    }
}
