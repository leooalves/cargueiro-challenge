using System;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Entidades
{
    public class MovimentacaoCargueiro : Entidade
    {
        public EClasseCargueiro ClasseCargueiro { get; private set; }
        public DateTime DataSaida { get; private set; }
        public DateTime? DataRetorno { get; private set; }
        public ETipoMineral? TipoMineralObtido { get; private set; }
        public decimal? QtdMaterialObtidoEmQuilos { get; private set; }

        public void RegistraRetorno(DateTime dataRetorno, ETipoMineral tipoMineralObtido, decimal qtdMaterialObtidoEmQuilos)
        {
            DataRetorno = dataRetorno;
            TipoMineralObtido = tipoMineralObtido;
            QtdMaterialObtidoEmQuilos = qtdMaterialObtidoEmQuilos;
        }

        public void RegistraSaida(EClasseCargueiro classeCargueiro, DateTime dataSaida)
        {
            ClasseCargueiro = classeCargueiro;
            DataSaida = dataSaida;
        }
    }
}