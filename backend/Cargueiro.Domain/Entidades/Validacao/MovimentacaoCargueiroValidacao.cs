using System;
using Flunt.Validations;

namespace Cargueiro.Domain.Entidades.Validacao
{
    public class MovimentacaoCargueiroValidacao : Contract<MovimentacaoCargueiro>
    {
        public MovimentacaoCargueiroValidacao(MovimentacaoCargueiro movimentacao)
        {
            Requires()
                .AreNotEquals(movimentacao.DataRetorno.DayOfWeek, DayOfWeek.Sunday, "DataSaida", "Não pode ocorrer movimentação aos domingos")
                .IsGreaterOrEqualsThan(movimentacao.DataSaida.Hour, 8, "DataSaida", "A data de saída do cargueiro ão pode ser antes das 08:00 AM")
                .AreNotEquals(movimentacao.DataSaida.DayOfWeek, DayOfWeek.Sunday, "DataSaida", "Não pode ocorrer movimentação aos domingos");
        }
    }
}