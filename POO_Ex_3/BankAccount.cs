using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_3
{
    public abstract class BankAccount
    {
        /*
            Crie uma classe abstrata Conta Bancaria que contém como atributos, numero da conta e o saldo, e como métodos abstratos sacar e depositar que recebem um parâmetro do tipo double.
        */

        public int AccountNumber { get; protected set; }
        public decimal Balance { get; protected set; }

        protected BankAccount(int accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public abstract void Withdraw(decimal valor);
        public abstract void Deposit(decimal valor);

        public virtual string GetAccountData()
            => $"Dados da Conta: Numero da Conta: {AccountNumber}, Saldo: {(Balance == 0 ? 0M : Balance):C}";

        public void ShowAccountData()
            => Console.WriteLine(GetAccountData());
    }
}
