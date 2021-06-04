using Cargueiro.Domain.Enums;
using Flunt.Notifications;
using System;

namespace Cargueiro.Domain.Application.Commands
{
    public class SaidaCargueiroCommand : Notifiable<Notification>, ICommand
    {
        public SaidaCargueiroCommand(EClasseCargueiro classeCargueiro, DateTime dataSaida)
        {
            ClasseCargueiro = classeCargueiro;
            DataSaida = dataSaida;
        }

        public EClasseCargueiro ClasseCargueiro { get; private set; }
        public DateTime DataSaida { get; private set; }

        public void Validar()
        {
            AddNotifications(new SaidaCargueiroValidacao(this));
        }
    }
}