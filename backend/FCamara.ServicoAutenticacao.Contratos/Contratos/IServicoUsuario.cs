using FCamara.ServicoAutenticacao.Contratos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.ServicoAutenticacao.Contratos.Contratos
{
    public interface IServicoUsuario
    {
        UsuarioDto Login(string login, string senha);
        void ArmazenarToken(int id, string token, DateTime dataExpiracao);
    }
}
