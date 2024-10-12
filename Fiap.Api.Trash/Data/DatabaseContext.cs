using Fiap.Api.Trash.Models;
using Microsoft.EntityFrameworkCore;
namespace Fiap.Api.Trash.Data
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<UsuarioModel> Usuarios { get; set; }
        public virtual DbSet<NotificacaoModel> Notificacoes { get; set; }
        public virtual DbSet<EletronicoModel> Eletronicos { get; set; }
        public virtual DbSet<DescarteModel> Descartes { get; set; }


        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>( entity => 
            {
                entity.ToTable("Usuarios");
                entity.HasKey(e=> e.UserId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            } );
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NotificacaoModel>(entity =>
            {
                entity.ToTable("Notificacoes");
                entity.HasKey(e=>e.NotificacaoId);
                entity.Property(e => e.Titulo).IsRequired();
                entity.Property(e => e.Mensagem).HasMaxLength(500);
                entity.Property(e => e.Data).HasColumnType("date");
                //relacionamento
                entity.HasOne(e => e.Usuario)
                    // Indica que um Usuario pode ter muitas notificações
                    .WithMany()
                    // Define a chave estrangeira
                    .HasForeignKey(e => e.UserId)
                    // Torna a chave estrangeira obrigatória
                    .IsRequired();


            });

            modelBuilder.Entity<EletronicoModel>(entity =>
            {
                entity.ToTable("Eletronicos");
                entity.HasKey(e => e.EletronicoId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Descricao).HasMaxLength(500);
                //relacionamento
                entity.HasOne(e => e.Usuario)
                    // Indica que um Usuario pode ter muitos eletronicos
                    .WithMany()
                    // Define a chave estrangeira
                    .HasForeignKey(e => e.UserId)
                    // Torna a chave estrangeira obrigatória
                    .IsRequired();
            });

            modelBuilder.Entity<DescarteModel>(entity =>
            {
                entity.ToTable("Descartes");
                entity.HasKey(e => e.DescarteId);
                entity.Property(e => e.Data).HasColumnType("date");
                entity.Property(e => e.Descricao).HasMaxLength(500);
                entity.Property(e => e.Endereco);
            });
        }  
    }
}
