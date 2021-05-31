using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using Cargueiro.Domain.Infra.Contexts;
using Cargueiro.Domain.Repositorios;
using System.Collections.Generic;

namespace Cargueiro.Domain.Infra.Repositorios
{
    public class FrotaCargueiroRepositorio : IFrotaCargueiroRepositorio
    {
        private readonly DataContext _context;
        public FrotaCargueiroRepositorio(DataContext context)
        {
            _context = context;
        }
        public void CargaInicialFrota()
        {
            _context.FrotaCargueiros.Add(new FrotaCargueiro(EClasseCargueiro.Classe_I, 15, 0, DateTime.Now));
            _context.FrotaCargueiros.Add(new FrotaCargueiro(EClasseCargueiro.Classe_II, 10, 0, DateTime.Now));
            _context.FrotaCargueiros.Add(new FrotaCargueiro(EClasseCargueiro.Classe_III, 3, 0, DateTime.Now));
            _context.FrotaCargueiros.Add(new FrotaCargueiro(EClasseCargueiro.Classe_IV, 2, 0, DateTime.Now));
            _context.SaveChanges();
        }

        public void AtualizaFrota(FrotaCargueiro frotaCargueiro)
        {
            _context.Entry(frotaCargueiro).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Task<FrotaCargueiro> RetornaFrota(EClasseCargueiro classeCargueiro)
        {
            return _context.FrotaCargueiros.FirstOrDefaultAsync(x => x.ClasseCargueiro == classeCargueiro);
        }
        public IEnumerable<FrotaCargueiro> TodasFrotas()
        {
            return _context.FrotaCargueiros.ToList();
        }
    }
}