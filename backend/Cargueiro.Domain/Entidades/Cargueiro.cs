using Cargueiro.Domain.Comum;
using Cargueiro.Domain.Enums;
using System.Collections.Generic;

namespace Cargueiro.Domain.Entidades
{
    public class ConfiguracaoCargueiro : Entidade
    {
        public EClasseCargueiro Classe { get; set; }
        public decimal CapacidadeEmQuilos { get; set; }
        public List<ETipoMineral> MineraisCompativeis { get; set; }
    }
}