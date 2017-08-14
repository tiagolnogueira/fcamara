using FCamara.Dominio;
using FCamara.Infra.Configuracao;
using System.Data.Entity;
using System;

namespace FCamara.Infra
{
    public class FCamaraContexto : DbContext, IDbContext
    {
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : EntidadeBase
        {
            return base.Set<TEntity>();
        }

        public FCamaraContexto()
        {
            //Database.SetInitializer(new DatabaseInitializer());
        }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoConfiguracao());
            modelBuilder.Configurations.Add(new UsuarioConfiguracao());
        }

        
    }
}
