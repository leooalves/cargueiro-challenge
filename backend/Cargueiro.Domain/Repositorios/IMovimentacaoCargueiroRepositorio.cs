using Cargueiro.Domain.Entidades;
using System.Collections.Generic;
using Cargueiro.Domain.Comum;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Repositorios
{
    public interface IMovimentacaoCargueiroRepositorio : IRepositorio<MovimentacaoCargueiro>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<MovimentacaoCargueiro> RetornaMovimentacao(string id);
        Task<IEnumerable<MovimentacaoCargueiro>> RetornaTodasMovimentacoes();
        Task<IEnumerable<MovimentacaoCargueiro>> RetornaMovimentacoes(int ano, int mes);

        void Cria(MovimentacaoCargueiro movimentacao);
        void Atualiza(MovimentacaoCargueiro movimentacao);

    }
}