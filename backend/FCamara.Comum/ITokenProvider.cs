using System;

namespace FCamara.Comum
{
    public interface ITokenProvider
    {
        void ArmazenarToken(Guid token, DateTime dataExpiracao);

        bool EhValido(Guid token);        
    }
}
