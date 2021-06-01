using System;
using Cargueiro.Domain.Commands.Validacao;
using Cargueiro.Domain.Enums;
using Flunt.Notifications;

namespace Cargueiro.Domain.Commands
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
            this.AddNotifications(new SaidaCargueiroValidacao(this));
        }
    }
}