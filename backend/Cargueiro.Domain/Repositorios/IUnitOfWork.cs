using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Repositorios
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));       
    }
}
