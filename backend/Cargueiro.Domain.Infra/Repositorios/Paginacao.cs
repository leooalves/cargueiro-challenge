using System.Collections.Generic;
using Cargueiro.Domain.Repositorios;

namespace Cargueiro.Domain.Infra.Repositorios
{
    public class ResultadoPaginado<T> : IResultadoPaginado<T>
    {
        public IList<T> Resultados { get; set; }
        public int PaginaAtual { get; set; }
        public int QuantidaDePaginas { get; set; }
        public int TamanhoDaPagina { get; set; }
        public int QuantidadeDeLinhas { get; set; }
    }
}
