using Microsoft.EntityFrameworkCore;
using Cargueiro.Domain.Entidades;

namespace Cargueiro.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<MovimentacaoCargueiro> MovimentacoesCargueiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimentacaoCargueiro>().ToTable("movimentacaoCargueiro");
            modelBuilder.Entity<MovimentacaoCargueiro>().Property(x => x.Id);
            modelBuilder.Entity<MovimentacaoCargueiro>().Property(x => x.QtdMaterialObtidoEmQuilos).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<MovimentacaoCargueiro>().Property(x => x.ClasseCargueiro).HasColumnType("int)");
            modelBuilder.Entity<MovimentacaoCargueiro>().Property(x => x.DataRetorno);
            modelBuilder.Entity<MovimentacaoCargueiro>().HasIndex(x => x.DataSaida);
            modelBuilder.Entity<MovimentacaoCargueiro>().Property(x => x.TipoMineralObtido).HasColumnType("int");
            modelBuilder.Entity<MovimentacaoCargueiro>().Ignore(x => x.Notifications);
            modelBuilder.Entity<MovimentacaoCargueiro>().Ignore(x => x.IsValid);

            base.OnModelCreating(modelBuilder);
        }

    }
}