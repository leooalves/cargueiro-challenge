using System;
using System.Threading.Tasks;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using Cargueiro.Domain.Repositorios;

namespace Cargueiro.Domain.Infra.Repositorios
{
    public class FrotaCargueiroRepositorio : IFrotaCargueiroRepositorio
    {

        public void AtualizaFrota(FrotaCargueiro frotaCargueiro)
        {

        }

        public Task<FrotaCargueiro> RetornaFrota(EClasseCargueiro classeCargueiro)
        {
            var frota = new FrotaCargueiro(classeCargueiro, 1, 1, DateTime.Now);
            return Task.FromResult(frota);
        }
    }
}