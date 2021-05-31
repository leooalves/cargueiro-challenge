
using System.Threading.Tasks;
using Cargueiro.Domain.Commands;

namespace Cargueiro.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<IResposta> Handle(T command);
    }
}