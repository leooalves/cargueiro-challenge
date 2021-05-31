using System.Collections.Generic;

namespace Cargueiro.Domain.Repositorios
{
    public interface IResultadoPaginado<T>
    {
        IList<T> Resultados { get; set; }
        int PaginaAtual { get; set; }
        int QuantidaDePaginas { get; set; }
        int TamanhoDaPagina { get; set; }
        int QuantidadeDeLinhas { get; set; }
    }
}
