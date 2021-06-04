using Cargueiro.Domain.Enums;
using Cargueiro.Domain.Entidades.Comum;

namespace Cargueiro.Domain.Entidades
{
    public class Mineral : Entidade
    {
        public ETipoMineral Tipo { get; private set; }
        public string Caracteristica { get; private set; }
        public decimal PrecoPorQuilo { get; private set; }

    }
}