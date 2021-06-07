using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using Cargueiro.Domain.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cargueiro.Domain.Infra.Repositorios
{
    public class ConfiguracaoCargueiroRepositorio : IConfiguracaoCargueiroRepositorio
    {
        public Task<ConfiguracaoCargueiro> RetornaCargueiroPorClasse(EClasseCargueiro classeCargueiro)
        {
            var cargueiro = new ConfiguracaoCargueiro();
            switch (classeCargueiro)
            {
                case EClasseCargueiro.Classe_I:
                    cargueiro = new ConfiguracaoCargueiro
                    {
                        Classe = EClasseCargueiro.Classe_I,
                        CapacidadeEmQuilos = 5000M,
                        MineraisCompativeis = new List<ETipoMineral> { 
                            ETipoMineral.Tipo_D
                        }
                    };
                    break;
                case EClasseCargueiro.Classe_II:
                    cargueiro = new ConfiguracaoCargueiro
                    {
                        Classe = EClasseCargueiro.Classe_II,
                        CapacidadeEmQuilos = 3000M,
                        MineraisCompativeis = new List<ETipoMineral> {
                            ETipoMineral.Tipo_A
                        }
                    };
                    break;
                case EClasseCargueiro.Classe_III:
                    cargueiro = new ConfiguracaoCargueiro
                    {
                        Classe = EClasseCargueiro.Classe_III,
                        CapacidadeEmQuilos = 2000M,
                        MineraisCompativeis = new List<ETipoMineral> {
                            ETipoMineral.Tipo_C
                        }
                    };
                    break;
                case EClasseCargueiro.Classe_IV:
                    cargueiro = new ConfiguracaoCargueiro
                    {
                        Classe = EClasseCargueiro.Classe_IV,
                        CapacidadeEmQuilos = 500M,
                        MineraisCompativeis = new List<ETipoMineral> {
                            ETipoMineral.Tipo_B,
                            ETipoMineral.Tipo_C
                        }
                    };
                    break;
            }

            return Task.FromResult(cargueiro);
        }
    }
}
