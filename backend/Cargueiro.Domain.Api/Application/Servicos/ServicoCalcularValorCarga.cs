

using Cargueiro.Domain.Enums;
using Cargueiro.Domain.Repositorios;

namespace Cargueiro.Domain.Api.Application.Servicos
{
    public class ServicoCalcularValorCarga
    {
        private readonly IMineralRepositorio _mineralRepositorio;

        public ServicoCalcularValorCarga(IMineralRepositorio mineralRepositorio)
        {
            _mineralRepositorio = mineralRepositorio;
        }

        public decimal Calcular(ETipoMineral tipoMineral, decimal quantidadeMineralQuilos)
        {
            var mineral = _mineralRepositorio.RetornaMineralPorTipo(tipoMineral);
            return mineral.PrecoEmDolaresPorQuilo * quantidadeMineralQuilos;
        }
    }
}
