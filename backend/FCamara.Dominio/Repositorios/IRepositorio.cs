using System.Collections.Generic;

namespace FCamara.Dominio.Repositorios
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        IList<T> Listar();
        T Obter(int id);
        int Persistir();
    }
}
