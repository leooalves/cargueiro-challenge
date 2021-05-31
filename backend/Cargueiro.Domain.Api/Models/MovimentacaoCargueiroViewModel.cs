using System;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Api.Models
{
    public class MovimentacaoCargueiroViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime? DataRetorno { get; set; }
        public EClasseCargueiro ClasseCargueiro { get; set; }
        public ETipoMineral? TipoMineralObtido { get; set; }
        public decimal? QtdMaterialObtidoEmQuilos { get; set; }
    }
}