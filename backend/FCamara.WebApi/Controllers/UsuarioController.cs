using FCamara.ServicoAutenticacao.Contratos.Contratos;
using FCamara.WebApi.Models;
using FCamara.WebApi.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FCamara.WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IServicoUsuario _servicoUsuario;

        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        [HttpPost]
        [Route("api/v1/usuario/login")]
        public IHttpActionResult Login(LoginModel dadosLogin)
        {
            if (string.IsNullOrWhiteSpace(dadosLogin.Login))
                return BadRequest("É obrigatório informar login!");

            if (string.IsNullOrWhiteSpace(dadosLogin.Senha))
                return BadRequest("É obrigátório informar senha!");

            var usuario = _servicoUsuario.Login(dadosLogin.Login, dadosLogin.Senha);

            if (usuario != null)
            {
                var token = JwtManager.GerarToken(usuario.Id, usuario.Login, 1);
                return Ok(new UsuarioModel() { Id = usuario.Id, Nome = usuario.Nome, Token = token });
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}
