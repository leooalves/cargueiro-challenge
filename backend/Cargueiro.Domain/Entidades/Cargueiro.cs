using Cargueiro.Domain.Enums;

namespace Cargueiro.Domain.Entidades
{
    public class Cargueiro : Entidade
    {
        public EClasseCargueiro Classe { get; private set; }
        public decimal CapacidadeEmQuilos { get; private set; }
        public string MineraisCompativeis { get; private set; }
    }
}