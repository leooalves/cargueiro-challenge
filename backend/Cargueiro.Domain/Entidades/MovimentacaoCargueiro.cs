using System;
using Cargueiro.Domain.Entidades.Validacao;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Entidades
{
    public class MovimentacaoCargueiro : Entidade, IValidavel
    {
        public EClasseCargueiro ClasseCargueiro { get; private set; }
        public DateTime DataRetorno { get; private set; }
        public DateTime DataSaida { get; private set; }
        public ETipoMineral TipoMineralObtido { get; private set; }
        public decimal QtdMaterialObtidoEmQuilos { get; private set; }

        public void Validar()
        {
            this.AddNotifications(new RetornoMovimentacaoCargueiroValidacao(this));
            this.AddNotifications(new SaidaMovimentacaoCargueiroValidacao(this));
        }

        public void RegistraRetorno(DateTime dataRetorno, ETipoMineral tipoMineralObtido, decimal qtdMaterialObtidoEmQuilos)
        {
            DataRetorno = dataRetorno;
            TipoMineralObtido = tipoMineralObtido;
            QtdMaterialObtidoEmQuilos = qtdMaterialObtidoEmQuilos;
            this.AddNotifications(new RetornoMovimentacaoCargueiroValidacao(this));
        }

        public void RegistraSaida(EClasseCargueiro classeCargueiro, DateTime dataSaida)
        {
            ClasseCargueiro = classeCargueiro;
            DataSaida = dataSaida;
            this.AddNotifications(new SaidaMovimentacaoCargueiroValidacao(this));
        }
    }
}