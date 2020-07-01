using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_3
{
    public class NormalBankAccount : BankAccount, IPrintableBankAccount
    {
        /*
         A Conta Corrente possui um atributo taxaDeOperação que é descontado sempre que um saque e um depósito são feitos.
         */
        private decimal _operationRate;

        public NormalBankAccount(int accountNumber, decimal operationRate) : base(accountNumber)
        {
            if (operationRate < 0)
            {
                throw new Exception("Valor não permitido para Taxa de Operação.");
            }

            _operationRate = operationRate;
        }

        public override void Deposit(decimal value)
        {
            if (value <= _operationRate)
            {
                throw new Exception("Valor não permitido para depósito.");
            }

            value -= _operationRate;
            Balance += value;
        }

        public override void Withdraw(decimal value)
        {
            if(value <= 0 || (value + _operationRate) > Balance)
            {
                throw new Exception("Valor não disponível pra saque.");
            }

            value += _operationRate;
            Balance -= value;
        }

        public override string GetAccountData()
            => $"{base.GetAccountData()}, Taxa de Operação: {_operationRate}, Saldo disponível para Saque: {((Balance - _operationRate) <= 0 ? 0M : (Balance - _operationRate)):C}";
    }
}
