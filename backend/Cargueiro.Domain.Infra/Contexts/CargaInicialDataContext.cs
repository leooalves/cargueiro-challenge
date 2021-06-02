using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargueiro.Domain.Entidades;
using Cargueiro.Domain.Enums;

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
                    new FrotaCargueiro(EClasseCargueiro.Classe_I, 10, 0, DateTime.Now),
                    new FrotaCargueiro(EClasseCargueiro.Classe_I, 3, 0, DateTime.Now),
                    new FrotaCargueiro(EClasseCargueiro.Classe_I, 2, 0, DateTime.Now)
                };
        }

    }
}

