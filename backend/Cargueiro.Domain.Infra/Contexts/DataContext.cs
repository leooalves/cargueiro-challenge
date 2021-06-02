using Microsoft.EntityFrameworkCore;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using System;
using Flunt.Notifications;
using Cargueiro.Domain.Infra.Mapeamentos;

namespace Cargueiro.Domain.Infra.Contexts
{
    public class DataContext : DbContext
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