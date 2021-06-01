using System.Collections.Generic;
using System.Threading.Tasks;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Repositorios
{
    public interface IFrotaCargueiroRepositorio
    {
        IEnumerable<FrotaCargueiro> TodasFrotas();
        Task<FrotaCargueiro> BuscaFrotaPorClasse(EClasseCargueiro classeCargueiro);

        void CargaInicialFrota();
        void AtualizaFrota(FrotaCargueiro frotaCargueiro);

    }

}