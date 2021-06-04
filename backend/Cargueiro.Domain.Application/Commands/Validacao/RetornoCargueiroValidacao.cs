using Flunt.Validations;
using System;

namespace Cargueiro.Domain.Application.Commands
{
    public class RetornoCargueiroValidacao : Contract<RetornoCargueiroCommand>
    {
        public RetornoCargueiroValidacao(RetornoCargueiroCommand movimentacao)
        {
            Requires()
                .AreNotEquals(movimentacao.DataRetorno.DayOfWeek, DayOfWeek.Sunday, "DataRetorno", "Não pode ocorrer movimentação aos domingos");
        }
    }
}