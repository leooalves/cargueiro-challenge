using Cargueiro.Domain.Comum;
using Cargueiro.Domain.Enums;
using Flunt.Validations;
using System;

namespace Cargueiro.Domain.Entidades
{
    public class MovimentacaoCargueiro : Entidade, IAggregateRoot
    {
        public EClasseCargueiro ClasseCargueiro { get; private set; }
        public DateTime DataSaida { get; private set; }
        public DateTime? DataRetorno { get; private set; }
        public ETipoMineral? TipoMineralObtido { get; private set; }
        public decimal? QtdMaterialObtidoEmQuilos { get; private set; }

        public void RegistraRetorno(DateTime dataRetorno, ETipoMineral tipoMineralObtido, decimal qtdMaterialObtidoEmQuilos)
        {
            DataRetorno = dataRetorno;
            TipoMineralObtido = tipoMineralObtido;
            QtdMaterialObtidoEmQuilos = qtdMaterialObtidoEmQuilos;
            AddNotifications(
               new Contract<MovimentacaoCargueiro>()
                   .Requires()
                   .AreNotEquals(DataRetorno.Value.DayOfWeek, DayOfWeek.Sunday, "DataRetorno", "Não pode ocorrer movimentação aos domingos")
           );
        }

        public void RegistraSaida(EClasseCargueiro classeCargueiro, DateTime dataSaida)
        {
            ClasseCargueiro = classeCargueiro;
            DataSaida = dataSaida;
            AddNotifications(
                new Contract<MovimentacaoCargueiro>()
                    .Requires()
                    .IsGreaterOrEqualsThan(DataSaida.Hour, 8, "DataSaida", "A data de saída do cargueiro não pode ser antes das 08:00 AM")
                    .AreNotEquals(DataSaida.DayOfWeek, DayOfWeek.Sunday, "DataSaida", "Não pode ocorrer movimentação aos domingos")
            );
        }
    }
}