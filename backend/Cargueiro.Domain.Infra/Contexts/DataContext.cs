using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Infra.Mapeamentos;
using Cargueiro.Domain.Comum;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Cargueiro.Domain.Infra.Contexts
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<MovimentacaoCargueiro> MovimentacoesCargueiros { get; set; }
        public DbSet<FrotaCargueiro> FrotaCargueiros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new MovimentacaoCargueiroMap());
            modelBuilder.ApplyConfiguration(new FrotaCargueiroMap());

        }

    }
}