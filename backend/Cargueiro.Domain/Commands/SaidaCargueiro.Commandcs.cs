using System;
using Cargueiro.Domain.Commands.Validacao;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Commands
{
    public class SaidaCargueiroCommand : Entidade, IValidavel
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