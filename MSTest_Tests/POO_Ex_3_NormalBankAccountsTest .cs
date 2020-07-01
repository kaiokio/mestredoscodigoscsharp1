using Microsoft.VisualStudio.TestTools.UnitTesting;
using POO_Ex_3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSTest_Tests
{
    [TestClass]
    public class POO_Ex_3_NormalBankAccountsTest
    {
        private const decimal OPERATION_RATE = 3.50M;
        private const string INVALID_VALUE_OPERATION_RATE = "Valor não permitido para Taxa de Operação.";
        private const string INVALID_VALUE_DEPOSIT = "Valor não permitido para depósito.";
        private const string INVALID_VALUE_WITHDRAW = "Valor não disponível pra saque.";

        [TestMethod]
        public void CreateNormalBankAccount_WithInvalidOperationRate_ShouldThrowException()
        {
            Func<NormalBankAccount> resultFunc = () => CreateNormalBankAccount(-1);

            Assert.ThrowsException<Exception>(resultFunc, INVALID_VALUE_OPERATION_RATE);
        }

        [TestMethod]
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

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(3.50)]
        public void DepositNormalBankAccount_WithInvalidValue_ShouldThrowException(double depositValue)
        {
            var account = CreateNormalBankAccount(OPERATION_RATE);

            Action resultAct = () => account.Deposit(Convert.ToDecimal(depositValue));

            Assert.ThrowsException<Exception>(resultAct, INVALID_VALUE_DEPOSIT);
        }

        [DataTestMethod]
        [DataRow(100, 96.5)]
        [DataRow(4.50, 1.00)]
        public void WithdrawNormalBankAccount_Success(double initialAccountBalance, double withdrawValue)
        {
            var account = CreateNormalBankAccountWithSpecificBalance(OPERATION_RATE, Convert.ToDecimal(initialAccountBalance));

            account.Withdraw(Convert.ToDecimal(withdrawValue));

            Assert.AreEqual(account.Balance, Convert.ToDecimal(initialAccountBalance) - Convert.ToDecimal(withdrawValue) - OPERATION_RATE);
        }

        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(3.50, 3.50)]
        [DataRow(100, 0)]
        [DataRow(100, -1)]
        [DataRow(0, 1)]
        public void WithdrawNormalBankAccount_WithValueGreaterThanLimit_ShouldThrowException(double initialAccountBalance, double withdrawValue)
        {
            var account = CreateNormalBankAccountWithSpecificBalance(OPERATION_RATE, Convert.ToDecimal(initialAccountBalance));

            Action resultAct = () => account.Withdraw(Convert.ToDecimal(withdrawValue));

            Assert.ThrowsException<Exception>(resultAct, INVALID_VALUE_WITHDRAW);
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