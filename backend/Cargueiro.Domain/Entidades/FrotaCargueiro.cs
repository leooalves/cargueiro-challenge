using Cargueiro.Domain.Comum;
using Cargueiro.Domain.Enums;
using System;

namespace Cargueiro.Domain.Entidades
{
    public class FrotaCargueiro : Entidade, IAggregateRoot
    {
        public FrotaCargueiro(EClasseCargueiro classeCargueiro, int quantidadeDisponivel, int quantidadeEmViagem, DateTime dataUltimaAtualizacao)
        {
            ClasseCargueiro = classeCargueiro;
            QuantidadeDisponivel = quantidadeDisponivel;
            QuantidadeEmViagem = quantidadeEmViagem;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
        }

        public EClasseCargueiro ClasseCargueiro { get; private set; }
        public int QuantidadeDisponivel { get; private set; }
        public int QuantidadeEmViagem { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        public bool NaoExisteCargueiroDisponivel
        {
            get
            {
                return QuantidadeDisponivel > 0 ? false : true;
            }
        }
        public bool NaoExisteCargueiroEmViagem
        {
            get
            {
                return QuantidadeEmViagem > 0 ? false : true;
            }
        }

        public void RegistraBaixaFrota()
        {
            if (QuantidadeDisponivel > 0)
            {
                QuantidadeDisponivel = --QuantidadeDisponivel;
                QuantidadeEmViagem = ++QuantidadeEmViagem;
                DataUltimaAtualizacao = DateTime.Now;
            }

        }
        public void RegistraRetornoFrota()
        {
            if (QuantidadeEmViagem > 0)
            {
                QuantidadeEmViagem = --QuantidadeEmViagem;
                QuantidadeDisponivel = ++QuantidadeDisponivel;
                DataUltimaAtualizacao = DateTime.Now;
            }

        }
    }
}