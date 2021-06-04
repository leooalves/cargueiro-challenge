
using Cargueiro.Domain.Api.Application.Commands;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Api.Application.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<IResposta> Handle(T command);
    }
}