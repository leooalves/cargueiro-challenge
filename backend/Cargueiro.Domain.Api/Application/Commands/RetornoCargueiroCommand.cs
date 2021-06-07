using Cargueiro.Domain.Enums;
using Flunt.Notifications;
using System;

namespace Cargueiro.Domain.Api.Application.Commands
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

        public string Id { get; set; }
        public EClasseCargueiro ClasseCargueiro { get; set; }
        public DateTime DataRetorno { get; set; }
        public ETipoMineral TipoMineralObtido { get; set; }
        public decimal QtdMaterialObtidoEmQuilos { get; set; }

        public void Validar()
        {
            AddNotifications(new RetornoCargueiroValidacao(this));
        }
    }
}