using FCamara.Dominio;
using System.Data.Entity;

namespace FCamara.Infra
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : EntidadeBase;
        int SaveChanges();
    }
}
