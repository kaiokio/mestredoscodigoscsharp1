using Microsoft.VisualStudio.TestTools.UnitTesting;
using POO_Ex_3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSTest_Tests
{
    [TestClass]
    public class POO_Ex_3_SpecialBankAccountsTest
    {
        private const decimal LIMIT = 1500M;
        private const string INVALID_LIMIT_VALUE = "Valor não permitido para limite.";
        private const string INVALID_VALUE_DEPOSIT = "Valor não permitido para depósito.";
        private const string INVALID_VALUE_WITHDRAW = "Valor não disponível pra saque.";

        [TestMethod]
        public void CreateSpecialBankAccount_WithInvalidLimitValue_ShouldThrowException()
        {
            Func<SpecialBankAccount> resultFunc = () => CreateSpecialBankAccount(-1);

            Assert.ThrowsException<Exception>(resultFunc, INVALID_LIMIT_VALUE);
        }

        [TestMethod]
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

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void DepositSpecialBankAccount_WithInvalidValue_ShouldThrowException(double depositValue)
        {
            var account = CreateSpecialBankAccount(LIMIT);

            Action resultAct = () => account.Deposit((decimal)depositValue);

            Assert.ThrowsException<Exception>(resultAct, INVALID_VALUE_DEPOSIT);
        }

        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(0, 1500)]
        [DataRow(100, 1600)]
        public void WithdrawSpecialBankAccount_Success(double initialAccountBalance, double withdrawValue)
        {
            var account = CreateSpecialBankAccountWithSpecificBalance(LIMIT, (decimal)initialAccountBalance);

            account.Withdraw((decimal)withdrawValue);

            Assert.AreEqual(account.Balance, (decimal)initialAccountBalance - (decimal)withdrawValue);
        }

        [DataTestMethod]
        [DataRow(100, -1)]
        [DataRow(100, 0)]
        [DataRow(0, 1501)]
        [DataRow(100, 1601)]
        public void WithdrawSpecialBankAccount_WithValueGreaterThanLimit_ShouldThrowException(double initialAccountBalance, double withdrawValue)
        {
            var account = CreateSpecialBankAccountWithSpecificBalance(LIMIT, (decimal)initialAccountBalance);

            Action resultAct = () => account.Withdraw((decimal)withdrawValue);

            Assert.ThrowsException<Exception>(resultAct, INVALID_VALUE_WITHDRAW);
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