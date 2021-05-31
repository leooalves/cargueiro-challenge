
using System.Collections.Generic;
using System.Threading.Tasks;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Repositorios;
using Cargueiro.Domain.Infra.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cargueiro.Domain.Infra.Repositorios
{
    public class MovimentacaoCargueiroRepositorio : IMovimentacaoCargueiroRepositorio
    {
        private readonly DataContext _context;
        public MovimentacaoCargueiroRepositorio(DataContext context)
        {
            _context = context;
        }

        public Task<MovimentacaoCargueiro> RetornaMovimentacao(string id)
        {
            return _context.MovimentacoesCargueiros.AsNoTracking().FirstOrDefaultAsync(x => x.Id.ToString() == id);
        }

        public async Task<IEnumerable<MovimentacaoCargueiro>> RetornaMovimentacoes(int ano, int mes)
        {
            return await _context.MovimentacoesCargueiros
                .Where(x => x.DataRetorno != null && x.DataRetorno.Value.Year == ano && x.DataRetorno.Value.Month == mes)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovimentacaoCargueiro>> RetornaTodasMovimentacoes()
        {
            return await _context.MovimentacoesCargueiros
                .ToListAsync();
        }

        public IResultadoPaginado<MovimentacaoCargueiro> RetornaMovimentacoesPaginado(int numeroPagina, int tamanhoPagina, int ano, int mes)
        {
            var results = from x in _context.MovimentacoesCargueiros
                          where x.DataRetorno != null
                              && x.DataRetorno.Value.Year == ano
                              && x.DataRetorno.Value.Month == mes
                          orderby x.DataSaida
                          select x;

            var result = RetornaResultadoPaginadoDaQuery(results, numeroPagina, tamanhoPagina);
            return result;
        }

        private static IResultadoPaginado<MovimentacaoCargueiro> RetornaResultadoPaginadoDaQuery(
            IQueryable<MovimentacaoCargueiro> query,
            int numeroPagina,
            int tamanhoPagina)
        {
            var result = new ResultadoPaginado<MovimentacaoCargueiro>();
            result.PaginaAtual = numeroPagina;
            result.TamanhoDaPagina = tamanhoPagina;
            result.QuantidadeDeLinhas = query.Count();
            var pageCount = (double)result.QuantidadeDeLinhas / tamanhoPagina;
            result.QuantidaDePaginas = (int)System.Math.Ceiling(pageCount);
            var skip = (numeroPagina - 1) * tamanhoPagina;
            result.Resultados = query.Skip(skip).Take(tamanhoPagina).ToList();

            return result;
        }

        public void Salva(MovimentacaoCargueiro movimentacao)
        {
            _context.MovimentacoesCargueiros.Add(movimentacao);
            _context.SaveChanges();
        }
    }
}