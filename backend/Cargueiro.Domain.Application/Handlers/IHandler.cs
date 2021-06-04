
using Cargueiro.Domain.Application.Commands;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Application.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<IResposta> Handle(T command);
    }
}