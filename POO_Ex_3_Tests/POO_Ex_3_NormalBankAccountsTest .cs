using NUnit.Framework;
using POO_Ex_3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUnit_Tests
{
    public class POO_Ex_3_NormalBankAccountsTest
    {
        private const decimal OPERATION_RATE = 3.50M;
        private const string INVALID_VALUE_OPERATION_RATE = "Valor não permitido para Taxa de Operação.";
        private const string INVALID_VALUE_DEPOSIT = "Valor não permitido para depósito.";
        private const string INVALID_VALUE_WITHDRAW = "Valor não disponível pra saque.";

        [Test]
        public void CreateNormalBankAccount_WithInvalidOperationRate_ShouldThrowException()
        {
            TestDelegate resultDelegate = () => CreateNormalBankAccount(-1);

            Assert.Throws<Exception>(resultDelegate, INVALID_VALUE_OPERATION_RATE);
        }

        [Test]
        public void DepositNormalBankAccount_Success()
        {
            var depositValues = new List<decimal> { 100, 123.12M, 3.51M };
            var account = CreateNormalBankAccount(OPERATION_RATE);

            depositValues.ForEach(value =>
            {
                account.Deposit(value);
            });

            Assert.AreEqual(account.Balance, depositValues.Sum(v => (v - OPERATION_RATE)));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3.50)]
        public void DepositNormalBankAccount_WithInvalidValue_ShouldThrowException(decimal depositValue)
        {
            var account = CreateNormalBankAccount(OPERATION_RATE);

            TestDelegate resultDelegate = () => account.Deposit(depositValue);

            Assert.Throws<Exception>(resultDelegate, INVALID_VALUE_DEPOSIT);
        }

        [TestCase(100, 96.5)]
        [TestCase(4.50, 1.00)]
        public void WithdrawNormalBankAccount_Success(decimal initialAccountBalance, decimal withdrawValue)
        {
            var account = CreateNormalBankAccountWithSpecificBalance(OPERATION_RATE, initialAccountBalance);

            account.Withdraw(withdrawValue);

            Assert.AreEqual(account.Balance, initialAccountBalance - withdrawValue - OPERATION_RATE);
        }

        [TestCase(100, 100)]
        [TestCase(3.50, 3.50)]
        [TestCase(100, 0)]
        [TestCase(100, -1)]
        [TestCase(0, 1)]
        public void WithdrawNormalBankAccount_WithValueGreaterThanLimit_ShouldThrowException(decimal initialAccountBalance, decimal withdrawValue)
        {
            var account = CreateNormalBankAccountWithSpecificBalance(OPERATION_RATE, initialAccountBalance);

            TestDelegate resultDelegate = () => account.Withdraw(withdrawValue);

            Assert.Throws<Exception>(resultDelegate, INVALID_VALUE_WITHDRAW);
        }

        private NormalBankAccount CreateNormalBankAccount(decimal operationRate)
            => new NormalBankAccount(123, operationRate);

        private NormalBankAccount CreateNormalBankAccountWithSpecificBalance(decimal operationRate, decimal balance)
        {
            if (balance > 0)
            {
                var bankAccount = new NormalBankAccount(123, operationRate);
                bankAccount.Deposit(balance + operationRate);

                return bankAccount;
            }

            return CreateNormalBankAccount(operationRate);
        }
    }
}