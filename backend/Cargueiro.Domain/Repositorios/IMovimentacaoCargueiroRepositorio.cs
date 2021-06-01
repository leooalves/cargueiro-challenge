using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cargueiro.Domain.Entidades;

namespace Cargueiro.Domain.Repositorios
{
    public interface IMovimentacaoCargueiroRepositorio
    {
        void Cria(MovimentacaoCargueiro movimentacao);
        void Atualiza(MovimentacaoCargueiro movimentacao);
        Task<MovimentacaoCargueiro> RetornaMovimentacao(string id);
        Task<IEnumerable<MovimentacaoCargueiro>> RetornaTodasMovimentacoes();
        Task<IEnumerable<MovimentacaoCargueiro>> RetornaMovimentacoes(int ano, int mes);
        IResultadoPaginado<MovimentacaoCargueiro> RetornaMovimentacoesPaginado(int page, int pageSize, int ano, int mes);
    }
}