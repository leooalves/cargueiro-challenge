using Cargueiro.Domain.Enums;
using System;

namespace Cargueiro.Domain.Api.Application.Queries
{
    public class MovimentacaoCargueiroViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public EClasseCargueiro ClasseCargueiro { get; set; }
        public ETipoMineral TipoMineralObtido { get; set; }
        public decimal QtdMaterialObtidoEmQuilos { get; set; }
        public decimal ValorTotalCargaEmDolares { get; set; }
    }
}