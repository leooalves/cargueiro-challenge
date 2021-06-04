
using Cargueiro.Domain.Repositorios;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Infra.Contexts;
using Cargueiro.Domain.Comum;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Cargueiro.Domain.Infra.Repositorios
{
    public class MovimentacaoCargueiroRepositorio : IMovimentacaoCargueiroRepositorio
    {
        private readonly DataContext _context;
        public MovimentacaoCargueiroRepositorio(DataContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

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

        public void Cria(MovimentacaoCargueiro movimentacao)
        {
            _context.Add(movimentacao);
        }

        public void Atualiza(MovimentacaoCargueiro movimentacao)
        {
            _context.Entry(movimentacao).State = EntityState.Modified;
        }
    }
}