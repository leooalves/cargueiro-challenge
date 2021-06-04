using Cargueiro.Domain.Enums;
using Flunt.Notifications;
using System;

namespace Cargueiro.Domain.Application.Commands
{
    public class RetornoCargueiroCommand : Notifiable<Notification>, ICommand
    {
        public RetornoCargueiroCommand(EClasseCargueiro classeCargueiro, DateTime dataRetorno, ETipoMineral tipoMineralObtido, decimal qtdMaterialObtidoEmQuilos)
        {
            ClasseCargueiro = classeCargueiro;
            DataRetorno = dataRetorno;
            TipoMineralObtido = tipoMineralObtido;
            QtdMaterialObtidoEmQuilos = qtdMaterialObtidoEmQuilos;
        }

        public string Id { get; private set; }
        public EClasseCargueiro ClasseCargueiro { get; private set; }
        public DateTime DataRetorno { get; private set; }
        public ETipoMineral TipoMineralObtido { get; private set; }
        public decimal QtdMaterialObtidoEmQuilos { get; private set; }

        public void Validar()
        {
            AddNotifications(new RetornoCargueiroValidacao(this));
        }
    }
}