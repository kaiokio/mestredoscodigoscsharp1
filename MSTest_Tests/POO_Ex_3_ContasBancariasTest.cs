using AutoFixture;
using Commom.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POO_Ex_3;
using System;
using System.Collections.Generic;

namespace MSTest_Tests
{
    [TestClass]
    public class POO_Ex_3_ContasBancariasTest
    {
        private Fixture _fixture;
        private Random _random;

        public POO_Ex_3_ContasBancariasTest()
        {
            _fixture = new Fixture();
            _random = new Random();
        }

        [TestMethod]
        public void DepositosContaCorrente_Success()
        {
            var valoresDeposito = _fixture.Create<List<double>>();
            var taxaOperacao = _random.GetRandomNumber(1, 10);
            var numeroConta = _fixture.Create<int>();

            var conta = new ContaCorrente(numeroConta, taxaOperacao);
            double valorSaldoEsperado = 0;

            valoresDeposito.ForEach(valor =>
            {
                conta.Depositar(valor);
                valorSaldoEsperado += valor - taxaOperacao;
            });

            Assert.IsTrue(conta.Saldo == valorSaldoEsperado);
        }

        [TestMethod]
        public void SaquesContaCorrente_Success()
        {
            var valorSaqueEDeposito = _random.GetRandomNumber(10, 1000);
            var taxaOperacao = _random.GetRandomNumber(1, 10);
            var numeroConta = _fixture.Create<int>();

            var conta = new ContaCorrente(numeroConta, taxaOperacao);
            double valorSaldoEsperado = 0;

            conta.Depositar(valorSaqueEDeposito);
            valorSaldoEsperado += valorSaqueEDeposito - taxaOperacao;

            conta.Sacar(valorSaldoEsperado - taxaOperacao);
            valorSaldoEsperado -= valorSaldoEsperado;

            Assert.IsTrue(conta.Saldo == valorSaldoEsperado);
        }

        [TestMethod]
        public void SaquesContaCorrenteAcimaLimite_ShouldThrowException()
        {
            var valorSaqueEDeposito = _random.GetRandomNumber(10, 1000);
            var taxaOperacao = _random.GetRandomNumber(1, 10);
            var numeroConta = _fixture.Create<int>();

            var conta = new ContaCorrente(numeroConta, taxaOperacao);
            double valorSaldoEsperado = 0;

            conta.Depositar(valorSaqueEDeposito);
            valorSaldoEsperado += valorSaqueEDeposito - taxaOperacao;

            Assert.ThrowsException<Exception>(() => conta.Sacar(valorSaldoEsperado));
        }


        [TestMethod]
        public void DepositosContaEspecial_Success()
        {
            var valoresDeposito = _fixture.Create<List<double>>();
            var limite = _fixture.Create<double>();
            var numeroConta = _fixture.Create<int>();

            var conta = new ContaEspecial(numeroConta, limite);
            double valorSaldoEsperado = 0;

            valoresDeposito.ForEach(valor =>
            {
                conta.Depositar(valor);
                valorSaldoEsperado += valor;
            });

            Assert.IsTrue(conta.Saldo == valorSaldoEsperado);
        }

        [TestMethod]
        public void SaquesContaEspecial_Success()
        {
            var valorSaqueEDeposito = _fixture.Create<double>();
            var limite = _fixture.Create<double>();
            var numeroConta = _fixture.Create<int>();

            var conta = new ContaEspecial(numeroConta, limite);
            double valorSaldoEsperado = 0;

            conta.Depositar(valorSaqueEDeposito);
            valorSaldoEsperado += valorSaqueEDeposito;

            conta.Sacar(valorSaqueEDeposito);
            valorSaldoEsperado -= valorSaqueEDeposito;

            Assert.IsTrue(conta.Saldo == valorSaldoEsperado);
        }


        [TestMethod]
        public void SaquesContaEspecialAcimaLimite_Success()
        {
            var valorSaqueEDeposito = _fixture.Create<double>();
            var limite = _fixture.Create<double>();
            var numeroConta = _fixture.Create<int>();

            var conta = new ContaEspecial(numeroConta, limite);
            double valorSaldoEsperado = 0;

            conta.Depositar(valorSaqueEDeposito);
            valorSaldoEsperado += valorSaqueEDeposito;

            conta.Sacar(valorSaqueEDeposito + limite);
            valorSaldoEsperado -= valorSaqueEDeposito + limite;

            Assert.IsTrue(conta.Saldo == valorSaldoEsperado);
        }


        [TestMethod]
        public void SaquesContaEspecialAcimaLimite_ShouldThrowException()
        {
            var valorSaqueEDeposito = _fixture.Create<double>();
            var limite = _fixture.Create<double>();
            var numeroConta = _fixture.Create<int>();

            var conta = new ContaEspecial(numeroConta, limite);
            double valorSaldoEsperado = 0;

            conta.Depositar(valorSaqueEDeposito);
            valorSaldoEsperado += valorSaqueEDeposito;

            Assert.ThrowsException<Exception>(() => conta.Sacar(valorSaqueEDeposito + limite + limite));
        }
    }
}
