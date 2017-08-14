using System;

namespace FCamara.Dominio
{
    public class Produto : EntidadeBase
    {
        public Produto(string nome, string descricao, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("Nome inválido");

            if (preco <= 0)
                throw new ArgumentNullException("Preço inválido");
            
            Nome = nome;
            Descricao = descricao;
            Preco = preco;            
        }        

        protected Produto()
        {

        }

        public string Nome { get; protected set; }

        public string Descricao { get; protected set; }

        public decimal Preco { get; protected set; }
    }
}
