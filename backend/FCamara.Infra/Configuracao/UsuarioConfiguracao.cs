using FCamara.Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FCamara.Infra.Configuracao
{
    public class UsuarioConfiguracao : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguracao()
        {
            ToTable("Usuarios");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasMaxLength(255)
                .IsRequired();

            Property(x => x.Login)
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Senha)
                .HasMaxLength(800)
                .IsRequired();

            Property(x => x.Token)
                .HasMaxLength(4000)
                .IsOptional();

            Property(x => x.DataExpiracao)
                .IsOptional();
        }
    }
}
