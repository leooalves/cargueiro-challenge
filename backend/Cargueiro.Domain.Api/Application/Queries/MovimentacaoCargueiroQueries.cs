using AutoMapper;
using Cargueiro.Domain.Api.Application.Servicos;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Infra.Contexts;
using Cargueiro.Domain.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Api.Application.Queries
{
    public class MovimentacaoCargueiroQueries
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ServicoCalcularValorCarga _servicoCalcularValorCarga;
        public MovimentacaoCargueiroQueries(DataContext context, IMapper mapper, ServicoCalcularValorCarga servicoCalcularValorCarga)
        {
            _context = context;
            _mapper = mapper;
            _servicoCalcularValorCarga = servicoCalcularValorCarga;
        }

        private async Task<IEnumerable<MovimentacaoCargueiroViewModel>> MovimentacoesPorPeriodo(int ano, int mes)
        {
            List<MovimentacaoCargueiro> movimentacoes = await _context.MovimentacoesCargueiros
                .Where(x => x.DataRetorno != null && x.DataRetorno.Value.Year == ano && x.DataRetorno.Value.Month == mes)
                .ToListAsync();

            List<MovimentacaoCargueiroViewModel> viewModel = _mapper
                .Map<List<MovimentacaoCargueiro>, List<MovimentacaoCargueiroViewModel>>(movimentacoes);

            foreach (var movimentacao in viewModel)
            {
                movimentacao.ValorTotalCargaEmDolares = _servicoCalcularValorCarga.Calcular(movimentacao.TipoMineralObtido, movimentacao.QtdMaterialObtidoEmQuilos);
            }

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

        public async Task<List<CargasMinerioPorPeriodoViewModel>> MovimentacoesPorMinerioPorPeriodo(int ano, int mes)
        {
            var movimentacoes = await MovimentacoesPorPeriodo(ano, mes);

            List<CargasMinerioPorPeriodoViewModel> cargas = movimentacoes.GroupBy(x => x.TipoMineralObtido).Select(y => new CargasMinerioPorPeriodoViewModel
            {
                TipoMineralObtido = y.Select(x => x.TipoMineralObtido).FirstOrDefault(),
                QtdMaterialObtidoEmQuilos = y.Sum(x=> x.QtdMaterialObtidoEmQuilos),
                ValorTotalMinerio = y.Sum(x=> x.ValorTotalCargaEmDolares)
            }).ToList();

         
            
            return cargas;
        }
    }
}
