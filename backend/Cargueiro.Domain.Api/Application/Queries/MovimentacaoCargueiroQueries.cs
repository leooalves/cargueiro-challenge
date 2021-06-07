using AutoMapper;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Api.Application.Queries
{
    public class MovimentacaoCargueiroQueries
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MovimentacaoCargueiroQueries(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private async Task<IEnumerable<MovimentacaoCargueiroViewModel>> MovimentacoesPorPeriodo(int ano, int mes)
        {
            List<MovimentacaoCargueiro> movimentacoes = await _context.MovimentacoesCargueiros
            //    .Where(x => x.DataRetorno != null && x.DataRetorno.Value.Year == ano && x.DataRetorno.Value.Month == mes)
                .ToListAsync();

            List<MovimentacaoCargueiroViewModel> viewModel = _mapper
                .Map<List<MovimentacaoCargueiro>, List<MovimentacaoCargueiroViewModel>>(movimentacoes);
            return viewModel;

        }

        public async Task<ItensPaginados<MovimentacaoCargueiroViewModel>> MovimentacoesPorPeriodoPaginado(int ano, int mes, int numeroDaPagina = 1, int tamanhoDaPagina = 10 )
        {

            var movimentacoes = await MovimentacoesPorPeriodo(ano, mes);

            var quantidadeTotalItems = movimentacoes.Count();

            movimentacoes = movimentacoes.Skip(tamanhoDaPagina * (numeroDaPagina-1)).Take((tamanhoDaPagina));

            var itensPaginados = new ItensPaginados<MovimentacaoCargueiroViewModel>(numeroDaPagina, tamanhoDaPagina, quantidadeTotalItems, movimentacoes);

            return itensPaginados;
        }
    }
}
