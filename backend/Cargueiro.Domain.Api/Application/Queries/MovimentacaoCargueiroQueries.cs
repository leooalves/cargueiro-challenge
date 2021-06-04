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
        public async Task<IEnumerable<MovimentacaoCargueiroViewModel>> RetornaMovimentacoesPorPeriodo(int ano, int mes)
        {
            List<MovimentacaoCargueiro> movimentacoes = await _context.MovimentacoesCargueiros
              //  .Where(x => x.DataRetorno != null && x.DataRetorno.Value.Year == ano && x.DataRetorno.Value.Month == mes)
                .ToListAsync();

            List<MovimentacaoCargueiroViewModel> viewModel = _mapper
                .Map<List<MovimentacaoCargueiro>,List<MovimentacaoCargueiroViewModel>>(movimentacoes);
            return viewModel;            
   
        }

        public async Task<MovimentacaoCargueiroViewModel> RetornaMovimentacao(string id)
        {
            var movimentacao = await _context.MovimentacoesCargueiros
                .Where(x => x.Id.ToString() == id).FirstOrDefaultAsync();
                

            var viewModel = _mapper
                .Map<MovimentacaoCargueiroViewModel>(movimentacao);
            return viewModel;
        }
    }
}
