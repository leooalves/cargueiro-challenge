
namespace Cargueiro.Domain.Comum
{
    public interface IRepositorio<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
