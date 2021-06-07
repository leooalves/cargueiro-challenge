using Cargueiro.Domain.Enums;
using Flunt.Notifications;
using System;

namespace Cargueiro.Domain.Api.Application.Commands
{
    public class SaidaCargueiroCommand : Notifiable<Notification>, ICommand
    {
        public SaidaCargueiroCommand(EClasseCargueiro classeCargueiro, DateTime dataSaida)
        {
            ClasseCargueiro = classeCargueiro;
            DataSaida = dataSaida;
        }

        public EClasseCargueiro ClasseCargueiro { get; set; }
        public DateTime DataSaida { get; set; }

        public void Validar()
        {
            AddNotifications(new SaidaCargueiroValidacao(this));
        }
    }
}