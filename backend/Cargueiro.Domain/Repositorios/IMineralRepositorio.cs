using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Repositorios
{
    public interface IMineralRepositorio
    {
        Mineral RetornaMineralPorTipo(ETipoMineral tipoMineral);
    }
}
