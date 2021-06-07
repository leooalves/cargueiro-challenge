using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using Cargueiro.Domain.Repositorios;

namespace Cargueiro.Domain.Infra.Repositorios
{
    public class MineralRepositorio : IMineralRepositorio
    {
        public Mineral RetornaMineralPorTipo(ETipoMineral tipoMineral)
        {
            var mineral = new Mineral(); 
            switch (tipoMineral)
            {
                case ETipoMineral.Tipo_A:
                    {
                        mineral = new Mineral
                        {
                            Tipo = ETipoMineral.Tipo_A,
                            Caracteristica = "Inflamável",
                            PrecoEmDolaresPorQuilo = 5000000M
                        };
                        break;
                    }
                case ETipoMineral.Tipo_B:
                    {
                        mineral = new Mineral
                        {
                            Tipo = ETipoMineral.Tipo_B,
                            Caracteristica = "Risco Biológico",
                            PrecoEmDolaresPorQuilo = 10M
                        };
                        break;
                    }
                case ETipoMineral.Tipo_C:
                    {
                        mineral = new Mineral
                        {
                            Tipo = ETipoMineral.Tipo_C,
                            Caracteristica = "Refrigerado",
                            PrecoEmDolaresPorQuilo = 300M
                        };
                        break;
                    }
                case ETipoMineral.Tipo_D:
                    {
                        mineral = new Mineral
                        {
                            Tipo = ETipoMineral.Tipo_D,
                            Caracteristica = "Sem características especiais",
                            PrecoEmDolaresPorQuilo = 10000M
                        };
                        break;
                    }
            }

            return mineral;
        }
    }
}
