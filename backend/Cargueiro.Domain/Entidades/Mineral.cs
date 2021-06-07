using Cargueiro.Domain.Comum;
using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Entidades
{
    public class Mineral : Entidade
    {
        public ETipoMineral Tipo { get; set; }
        public string Caracteristica { get; set; }
        public decimal PrecoEmDolaresPorQuilo { get; set; }

    }
}