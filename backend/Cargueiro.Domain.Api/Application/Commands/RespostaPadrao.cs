namespace Cargueiro.Domain.Api.Application.Commands
{
    public class RespostaPadrao : IResposta
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
    }
}