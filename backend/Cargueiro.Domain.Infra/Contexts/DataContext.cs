using Microsoft.EntityFrameworkCore;
using Cargueiro.Domain.Entidades;
using Flunt.Notifications;
using Cargueiro.Domain.Infra.Mapeamentos;
using Cargueiro.Domain.Repositorios;

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