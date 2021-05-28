using System;
using Flunt.Notifications;

namespace Cargueiro.Domain.Entidades
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