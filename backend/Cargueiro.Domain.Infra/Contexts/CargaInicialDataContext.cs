
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cargueiro.Domain.Infra.Contexts
{
    public class CargaInicialDataContext
    {
        public static void Seed(DataContext context)
        {
            if (!context.FrotaCargueiros.Any())
            {
                context.FrotaCargueiros.AddRange(CargaInicialFrota());

                context.SaveChangesAsync();
            }
        }

        private static IEnumerable<FrotaCargueiro> CargaInicialFrota()
        {
            return new List<FrotaCargueiro>()
                {
                    new FrotaCargueiro(EClasseCargueiro.Classe_I, 15, 0, DateTime.Now),
                    new FrotaCargueiro(EClasseCargueiro.Classe_II, 10, 0, DateTime.Now),
                    new FrotaCargueiro(EClasseCargueiro.Classe_III, 3, 0, DateTime.Now),
                    new FrotaCargueiro(EClasseCargueiro.Classe_IV, 2, 0, DateTime.Now)
                };
        }

    }
}

