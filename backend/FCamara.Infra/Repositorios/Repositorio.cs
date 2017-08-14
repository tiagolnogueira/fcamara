using FCamara.Dominio;
using FCamara.Dominio.Repositorios;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FCamara.Infra.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : EntidadeBase
    {
        private readonly IDbContext _contexto;
        private IDbSet<T> _entities;

        public Repositorio(IDbContext contexto)
        {
            this._contexto = contexto;
        }

        protected virtual IDbSet<T> Entidades
        {
            get
            {
                if (_entities == null)
                    _entities = _contexto.Set<T>();
                return _entities;
            }
        }

        public IList<T> Listar()
        {
            return Entidades.ToList();
        }        

        public T Obter(int id)
        {
            return Entidades.FirstOrDefault(x => x.Id == id);
        }

        public int Persistir()
        {
            return _contexto.SaveChanges();
        }
    }
}
