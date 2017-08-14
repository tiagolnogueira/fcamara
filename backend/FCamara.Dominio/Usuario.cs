using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.Dominio
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
    }
}
