using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Comum
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
