using FCamara.Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FCamara.Infra.Configuracao
{
    public class ProdutoConfiguracao : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguracao()
        {
            ToTable("Produtos");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Descricao)
                .HasMaxLength(400)
                .IsOptional();

            Property(x => x.Preco)
                .HasPrecision(9, 2);
        }
    }
}
