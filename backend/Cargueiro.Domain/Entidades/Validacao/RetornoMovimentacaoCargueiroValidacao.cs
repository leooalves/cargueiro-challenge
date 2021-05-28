using System;
using Flunt.Validations;

namespace Cargueiro.Domain.Entidades.Validacao
{
    public class RetornoMovimentacaoCargueiroValidacao : Contract<MovimentacaoCargueiro>
    {
        public RetornoMovimentacaoCargueiroValidacao(MovimentacaoCargueiro movimentacao)
        {
            Requires()
                .AreNotEquals(movimentacao.DataRetorno.DayOfWeek, DayOfWeek.Sunday, "DataRetorno", "Não pode ocorrer movimentação aos domingos")
                .IsGreaterOrEqualsThan(movimentacao.QtdMaterialObtidoEmQuilos, 0, "QtdMaterialObtidoEmQuilos", "Não pode ser obtido um número negativo de materiais");

        }
    }
}