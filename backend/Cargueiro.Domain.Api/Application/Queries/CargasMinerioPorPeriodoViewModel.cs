using Cargueiro.Domain.Enums;


namespace Cargueiro.Domain.Api.Application.Queries
{
    public class CargasMinerioPorPeriodoViewModel
    {
        public ETipoMineral TipoMineralObtido { get; set; }
        public decimal QtdMaterialObtidoEmQuilos { get; set; }
        public decimal ValorTotalMineralEmDolares { get; set; }
    }
}
