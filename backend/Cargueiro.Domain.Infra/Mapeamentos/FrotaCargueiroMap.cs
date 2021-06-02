using Cargueiro.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cargueiro.Domain.Infra.Mapeamentos
{
    class FrotaCargueiroMap : IEntityTypeConfiguration<FrotaCargueiro>
    {
        public void Configure(EntityTypeBuilder<FrotaCargueiro> builder)
        {
            builder.ToTable("frotaCargueiro");
            builder.Property(x => x.Id);
            builder.Property(x => x.ClasseCargueiro).HasColumnType("int");
            builder.Property(x => x.DataUltimaAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.QuantidadeDisponivel).HasColumnType("int");
            builder.Property(x => x.QuantidadeEmViagem).HasColumnType("int");
            builder.Ignore(x => x.IsValid);
            builder.Ignore(x => x.NaoExisteCargueiroDisponivel);
            builder.Ignore(x => x.NaoExisteCargueiroEmViagem);
            builder.Ignore(x => x.Notifications);
        }
    }
}
