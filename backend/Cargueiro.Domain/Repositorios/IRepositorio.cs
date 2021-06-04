using Cargueiro.Domain.Entidades.Comum;

namespace Cargueiro.Domain.Repositorios
{
    public interface IRepositorio<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
