using System;
using Cargueiro.Domain.Entidades.Validacao;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Entidades
{
    public class MovimentacaoCargueiro : Entidade
    {
        public MovimentacaoCargueiro(EClasseCargueiro classeCargueiro, DateTime dataSaida)
        {
            ClasseCargueiro = classeCargueiro;
            DataSaida = dataSaida;
        }

        public EClasseCargueiro ClasseCargueiro { get; private set; }
        public DateTime DataRetorno { get; private set; }
        public DateTime DataSaida { get; private set; }
        public ETipoMineral TipoMineralObtido { get; private set; }
        public decimal QtdMaterialObtidoEmQuilos { get; private set; }

        public void Validar()
        {
            this.AddNotifications(new MovimentacaoCargueiroValidacao(this));
        }
    }
}