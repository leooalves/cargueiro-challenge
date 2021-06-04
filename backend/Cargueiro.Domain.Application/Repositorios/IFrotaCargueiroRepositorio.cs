using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using Cargueiro.Domain.Comum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Application.Repositorios
{
    public interface IFrotaCargueiroRepositorio : IRepositorio<FrotaCargueiro>
    {
        IEnumerable<FrotaCargueiro> TodasFrotas();
        Task<FrotaCargueiro> BuscaFrotaPorClasse(EClasseCargueiro classeCargueiro);

        void AtualizaFrota(FrotaCargueiro frotaCargueiro);

    }

}