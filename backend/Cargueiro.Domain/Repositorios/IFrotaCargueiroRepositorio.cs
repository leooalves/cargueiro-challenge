using System.Threading.Tasks;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Repositorios
{
    public interface IFrotaCargueiroRepositorio
    {
        Task<FrotaCargueiro> RetornaFrota(EClasseCargueiro classeCargueiro);
        void AtualizaFrota(FrotaCargueiro frotaCargueiro);
    }

}