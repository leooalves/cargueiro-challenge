using System;
using Flunt.Validations;

namespace Cargueiro.Domain.Entidades.Validacao
{
    public class SaidaMovimentacaoCargueiroValidacao : Contract<MovimentacaoCargueiro>
    {
        public SaidaMovimentacaoCargueiroValidacao(MovimentacaoCargueiro movimentacao)
        {
            Requires()
                .IsGreaterOrEqualsThan(movimentacao.DataSaida.Hour, 8, "DataSaida", "A data de saída do cargueiro ão pode ser antes das 08:00 AM")
                .AreNotEquals(movimentacao.DataSaida.DayOfWeek, DayOfWeek.Sunday, "DataSaida", "Não pode ocorrer movimentação aos domingos");
        }
    }
}