using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Entidades
{
    public class Mineral : Entidade
    {
        public ETipoMineral Tipo { get; private set; }
        public string Caracteristica { get; private set; }
        public decimal PrecoPorQuilo { get; private set; }

    }
}