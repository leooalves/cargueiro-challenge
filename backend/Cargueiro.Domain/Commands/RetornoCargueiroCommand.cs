using System;
using Cargueiro.Domain.Commands.Validacao;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Commands
{
    public class RetornoCargueiroCommand : Entidade, IValidavel
    {
        public RetornoCargueiroCommand(EClasseCargueiro classeCargueiro, DateTime dataRetorno, ETipoMineral tipoMineralObtido, decimal qtdMaterialObtidoEmQuilos)
        {
            ClasseCargueiro = classeCargueiro;
            DataRetorno = dataRetorno;
            TipoMineralObtido = tipoMineralObtido;
            QtdMaterialObtidoEmQuilos = qtdMaterialObtidoEmQuilos;
        }

        public EClasseCargueiro ClasseCargueiro { get; private set; }
        public DateTime DataRetorno { get; private set; }
        public ETipoMineral TipoMineralObtido { get; private set; }
        public decimal QtdMaterialObtidoEmQuilos { get; private set; }

        public void Validar()
        {
            this.AddNotifications(new RetornoCargueiroValidacao(this));
        }
    }
}