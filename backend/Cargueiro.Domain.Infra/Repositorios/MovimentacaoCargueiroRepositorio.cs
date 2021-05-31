
using System.Collections.Generic;
using System.Threading.Tasks;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Repositorios;
using Cargueiro.Domain.Infra.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Cargueiro.Domain.Infra.Repositorios
{
    public class MovimentacaoCargueiroRepositorio : IMovimentacaoCargueiroRepositorio
    {
        private readonly DataContext _context;
        public MovimentacaoCargueiroRepositorio(DataContext context)
        {
            _context = context;
        }

        public Task<MovimentacaoCargueiro> RetornaMovimentacao()
        {
            return _context.MovimentacoesCargueiros.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MovimentacaoCargueiro>> RetornaMovimentacoes(int ano, int mes)
        {
            return await _context.MovimentacoesCargueiros
                //  .Where(x => x.DataRetorno.Year == ano && x.DataRetorno.Month == mes)
                .ToListAsync();
        }

        public void Salva(MovimentacaoCargueiro movimentacao)
        {
            _context.MovimentacoesCargueiros.Add(movimentacao);
            _context.SaveChanges();
        }
    }
}