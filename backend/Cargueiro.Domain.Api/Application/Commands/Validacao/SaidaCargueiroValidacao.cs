using Flunt.Validations;
using System;

namespace Cargueiro.Domain.Api.Application.Commands
{
    public class SaidaCargueiroValidacao : Contract<SaidaCargueiroCommand>
    {
        public SaidaCargueiroValidacao(SaidaCargueiroCommand movimentacao)
        {
            Requires()
                .IsGreaterOrEqualsThan(movimentacao.DataSaida.Hour, 8, "DataSaida", "A data de saída do cargueiro não pode ser antes das 08:00 AM")
                .AreNotEquals(movimentacao.DataSaida.DayOfWeek, DayOfWeek.Sunday, "DataSaida", "Não pode ocorrer movimentação aos domingos");
        }
    }
}