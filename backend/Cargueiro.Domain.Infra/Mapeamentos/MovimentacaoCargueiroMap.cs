using Cargueiro.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cargueiro.Domain.Infra.Mapeamentos
{
    class MovimentacaoCargueiroMap : IEntityTypeConfiguration<MovimentacaoCargueiro>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoCargueiro> builder)
        {

            builder.ToTable("movimentacaoCargueiro");
            builder.Property(x => x.Id);
            builder.Property(x => x.QtdMaterialObtidoEmQuilos).HasColumnType("decimal(10,2)");
            builder.Property(x => x.ClasseCargueiro).HasColumnType("int)");
            builder.Property(x => x.DataRetorno);
            builder.HasIndex(x => x.DataSaida);
            builder.Property(x => x.TipoMineralObtido).HasColumnType("int");
            builder.Ignore(x => x.Notifications);
            builder.Ignore(x => x.IsValid);
        }
    }
}
