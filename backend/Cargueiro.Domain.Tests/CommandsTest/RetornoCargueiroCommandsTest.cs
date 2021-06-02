
using System;
using Cargueiro.Domain.Commands;
using Cargueiro.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cargueiro.Domain.Tests.Commands
{
    [TestClass]
    public class RetornoCargueiroCommandsTest
    {

        private readonly RetornoCargueiroCommand _retornoCargueiroDomingo = new RetornoCargueiroCommand(EClasseCargueiro.Classe_I, new DateTime(2021, 05, 30, 20, 20, 0), ETipoMineral.Tipo_A, 10);

        private readonly RetornoCargueiroCommand _retornoCargueiroValido = new RetornoCargueiroCommand(EClasseCargueiro.Classe_I, new DateTime(2021, 05, 28, 20, 20, 0), ETipoMineral.Tipo_A, 10);

        public RetornoCargueiroCommandsTest()
        {
            _retornoCargueiroDomingo.Validar();
            _retornoCargueiroValido.Validar();
        }

        [TestMethod]
        public void Dada_uma_retorno_no_domingo_deve_ser_invalido()
        {
            Assert.AreEqual(_retornoCargueiroDomingo.IsValid, false);
        }

        [TestMethod]
        public void Dada_uma_retorno_valido()
        {
            Assert.AreEqual(_retornoCargueiroValido.IsValid, true);
        }


    }
}