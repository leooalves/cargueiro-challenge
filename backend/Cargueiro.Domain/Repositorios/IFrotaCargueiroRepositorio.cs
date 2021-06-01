using System.Collections.Generic;
using System.Threading.Tasks;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Repositorios
{
    public interface IFrotaCargueiroRepositorio
    {
        void CargaInicialFrota();
        Task<FrotaCargueiro> BuscaFrotaPorClasse(EClasseCargueiro classeCargueiro);
        void AtualizaFrota(FrotaCargueiro frotaCargueiro);
        IEnumerable<FrotaCargueiro> TodasFrotas();
    }

}