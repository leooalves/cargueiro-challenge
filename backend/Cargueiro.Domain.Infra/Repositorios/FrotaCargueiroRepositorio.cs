using Cargueiro.Domain.Repositorios;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using Cargueiro.Domain.Infra.Contexts;
using Cargueiro.Domain.Comum;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Infra.Repositorios
{
    public class FrotaCargueiroRepositorio : IFrotaCargueiroRepositorio
    {
        private readonly DataContext _context;
        public FrotaCargueiroRepositorio(DataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AtualizaFrota(FrotaCargueiro frotaCargueiro)
        {
            _context.Entry(frotaCargueiro).State = EntityState.Modified;            
        }

        public Task<FrotaCargueiro> BuscaFrotaPorClasse(EClasseCargueiro classeCargueiro)
        {
            return _context.FrotaCargueiros.FirstOrDefaultAsync(x => x.ClasseCargueiro == classeCargueiro);
        }
        public IEnumerable<FrotaCargueiro> TodasFrotas()
        {
            return _context.FrotaCargueiros.ToList();
        }
    }
}