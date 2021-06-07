using System;
using System.Collections.Generic;


namespace Cargueiro.Domain.Api.Application.Queries
{
    public class ItensPaginados<TEntity> where TEntity : class
    {
        public ItensPaginados(int numeroDaPagina, int tamanhoDaPagina, int totalItems, IEnumerable<TEntity> dados)
        {
            NumeroDaPagina = numeroDaPagina;
            ItensPorPagina = tamanhoDaPagina;
            TotalItems = totalItems;
            Dados = dados;
        }

        public int NumeroDaPagina { get; private set; }

        public int ItensPorPagina { get; private set; }

        public decimal TotalPaginas
        {
            get
            {
                return Math.Ceiling(Convert.ToDecimal((decimal)TotalItems / (decimal)ItensPorPagina));
            }
        }

        public int TotalItems { get; private set; }

        public IEnumerable<TEntity> Dados { get; private set; }


    }
}
