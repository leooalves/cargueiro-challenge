using System.Collections.Generic;

namespace Cargueiro.Domain.Repositorios
{
    public class ResultadoPaginado<T>
    {
        public IList<T> Resultados { get; set; }
        public int PaginaAtual { get; set; }
        public int QuantidaDePaginas { get; set; }
        public int TamanhoDaPagina { get; set; }
        public int QuantidadeDeLinhas { get; set; }
    }
}
