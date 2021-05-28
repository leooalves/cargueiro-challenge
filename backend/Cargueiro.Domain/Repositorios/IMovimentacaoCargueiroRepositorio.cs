using Cargueiro.Domain.Entidades;

namespace Cargueiro.Domain.Repositorios
{
    public interface IMovimentacaoCargueiroRepositorio
    {
        void Salva(MovimentacaoCargueiro movimentacao);
        MovimentacaoCargueiro RetornaMovimentacao();
    }
}