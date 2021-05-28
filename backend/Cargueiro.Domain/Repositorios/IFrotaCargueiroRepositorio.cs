using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Repositorios
{
    public interface IFrotaCargueiroRepositorio
    {
        FrotaCargueiro RetornaFrota(EClasseCargueiro classeCargueiro);
        void AtualizaFrota(FrotaCargueiro frotaCargueiro);
    }

}