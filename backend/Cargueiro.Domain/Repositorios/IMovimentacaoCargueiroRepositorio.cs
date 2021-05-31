using System.Collections.Generic;
using System.Threading.Tasks;
using Cargueiro.Domain.Entidades;

namespace Cargueiro.Domain.Repositorios
{
    public interface IMovimentacaoCargueiroRepositorio
    {
        void Salva(MovimentacaoCargueiro movimentacao);
        Task<MovimentacaoCargueiro> RetornaMovimentacao();

        Task<IEnumerable<MovimentacaoCargueiro>> RetornaMovimentacoes(int ano, int mes);
    }
}