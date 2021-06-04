using Flunt.Notifications;
using System;

namespace Cargueiro.Domain.Comum
{
    public abstract class Entidade : Notifiable<Notification>
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

    }
}