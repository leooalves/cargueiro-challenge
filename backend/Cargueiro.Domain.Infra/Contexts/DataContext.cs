using Microsoft.EntityFrameworkCore;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using System;

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

        public void CargaInicialFrota()
        {
            FrotaCargueiros.Add(new FrotaCargueiro(EClasseCargueiro.Classe_I, 15, 0, DateTime.Now));
            FrotaCargueiros.Add(new FrotaCargueiro(EClasseCargueiro.Classe_I, 10, 0, DateTime.Now));
            FrotaCargueiros.Add(new FrotaCargueiro(EClasseCargueiro.Classe_I, 3, 0, DateTime.Now));
            FrotaCargueiros.Add(new FrotaCargueiro(EClasseCargueiro.Classe_I, 2, 0, DateTime.Now));
            this.SaveChanges();
        }

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

            modelBuilder.Entity<FrotaCargueiro>().ToTable("frotaCargueiro");
            modelBuilder.Entity<FrotaCargueiro>().Property(x => x.Id);
            modelBuilder.Entity<FrotaCargueiro>().Property(x => x.ClasseCargueiro).HasColumnType("int");
            modelBuilder.Entity<FrotaCargueiro>().Property(x => x.DataUltimaAtualizacao).HasColumnType("datetime");
            modelBuilder.Entity<FrotaCargueiro>().Property(x => x.QuantidadeDisponivel).HasColumnType("int");
            modelBuilder.Entity<FrotaCargueiro>().Property(x => x.QuantidadeEmViagem).HasColumnType("int");
            modelBuilder.Entity<FrotaCargueiro>().Ignore(x => x.IsValid);
            modelBuilder.Entity<FrotaCargueiro>().Ignore(x => x.NaoExisteCargueiroDisponivel);
            modelBuilder.Entity<FrotaCargueiro>().Ignore(x => x.NaoExisteCargueiroEmViagem);
            modelBuilder.Entity<FrotaCargueiro>().Ignore(x => x.Notifications);

            base.OnModelCreating(modelBuilder);
        }

    }
}