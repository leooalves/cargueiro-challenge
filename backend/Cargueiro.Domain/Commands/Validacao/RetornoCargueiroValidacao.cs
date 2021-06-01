using System;
using Flunt.Validations;

namespace Cargueiro.Domain.Commands.Validacao
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