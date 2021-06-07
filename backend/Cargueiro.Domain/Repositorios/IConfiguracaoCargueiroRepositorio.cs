using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Repositorios
{
    public interface IConfiguracaoCargueiroRepositorio
    {
        Task<ConfiguracaoCargueiro> RetornaCargueiroPorClasse(EClasseCargueiro classeCargueiro);
    }
}
