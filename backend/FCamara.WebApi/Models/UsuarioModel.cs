using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCamara.WebApi.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Token { get; set; }
    }
}