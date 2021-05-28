
using System;
using Cargueiro.Domain.Commands;
using Cargueiro.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cargueiro.Domain.Tests.Commands
{
    [TestClass]
    public class SaidaCargueiroCommandsTest
    {
        private readonly SaidaCargueiroCommand _saidaCargueiroAntes08 = new SaidaCargueiroCommand(EClasseCargueiro.Classe_I, new DateTime(2021, 05, 28, 07, 0, 0));
        private readonly SaidaCargueiroCommand _saidaCargueiroDomingo = new SaidaCargueiroCommand(EClasseCargueiro.Classe_I, new DateTime(2021, 05, 30));
        private readonly SaidaCargueiroCommand _saidaCargueiroValida = new SaidaCargueiroCommand(EClasseCargueiro.Classe_I, new DateTime(2021, 05, 28, 10, 20, 0));

        [TestMethod]
        public void Dada_uma_saida_antes_das_08_AM_ela_deve_ser_invalida()
        {
            _saidaCargueiroAntes08.Validar();
            Assert.AreEqual(_saidaCargueiroAntes08.IsValid, false);
        }

        [TestMethod]
        public void Dada_uma_saida_no_domingo_deve_ser_invalida()
        {
            Assert.AreEqual(_saidaCargueiroDomingo.IsValid, false);
        }

        [TestMethod]
        public void Dada_uma_saida_valida()
        {
            Assert.AreEqual(_saidaCargueiroValida.IsValid, true);
        }


    }
}