using AutoFixture;
using NUnit.Framework;
using POO_Ex_3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUnit_Tests
{
    public class POO_Ex_3_SpecialBankAccountsTest
    {
        private const decimal LIMIT = 1500M;
        private const string INVALID_LIMIT_VALUE = "Valor não permitido para limite.";
        private const string INVALID_VALUE_DEPOSIT = "Valor não permitido para depósito.";
        private const string INVALID_VALUE_WITHDRAW = "Valor não disponível pra saque.";

        [Test]
        public void CreateSpecialBankAccount_WithInvalidLimitValue_ShouldThrowException()
        {
            TestDelegate resultDelegate = () => CreateSpecialBankAccount(-1);

            Assert.Throws<Exception>(resultDelegate, INVALID_LIMIT_VALUE);
        }

        [Test]
        public void DepositSpecialBankAccount_Success()
        {
            var depositValues = new List<decimal> { 100, 123.12M, 3.50M };
            var account = CreateSpecialBankAccount(LIMIT);

            depositValues.ForEach(value =>
            {
                account.Deposit(value);
            });

            Assert.AreEqual(account.Balance, depositValues.Sum(v => v));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void DepositSpecialBankAccount_WithInvalidValue_ShouldThrowException(decimal depositValue)
        {
            var account = CreateSpecialBankAccount(LIMIT);

            TestDelegate resultDelegate = () => account.Deposit(depositValue);

            Assert.Throws<Exception>(resultDelegate, INVALID_VALUE_DEPOSIT);
        }

        [TestCase(100, 100)]
        [TestCase(0, 1500)]
        [TestCase(100, 1600)]
        public void WithdrawSpecialBankAccount_Success(decimal initialAccountBalance, decimal withdrawValue)
        {
            var account = CreateSpecialBankAccountWithSpecificBalance(LIMIT, initialAccountBalance);

            account.Withdraw(withdrawValue);

            Assert.AreEqual(account.Balance, initialAccountBalance - withdrawValue);
        }

        [TestCase(100, -1)]
        [TestCase(100, 0)]
        [TestCase(0, 1501)]
        [TestCase(100, 1601)]
        public void WithdrawSpecialBankAccount_WithValueGreaterThanLimit_ShouldThrowException(decimal initialAccountBalance, decimal withdrawValue)
        {
            var account = CreateSpecialBankAccountWithSpecificBalance(LIMIT, initialAccountBalance);

            TestDelegate resultDelegate = () => account.Withdraw(withdrawValue);

            Assert.Throws<Exception>(resultDelegate, INVALID_VALUE_WITHDRAW);
        }

        private SpecialBankAccount CreateSpecialBankAccount(decimal limit)
            => new SpecialBankAccount(123, limit);

        private SpecialBankAccount CreateSpecialBankAccountWithSpecificBalance(decimal limit, decimal balance)
        {
            if (balance > 0)
            {
                var bankAccount = new SpecialBankAccount(123, limit);
                bankAccount.Deposit(balance);

                return bankAccount;
            }

            return CreateSpecialBankAccount(limit);
        }
    }
}