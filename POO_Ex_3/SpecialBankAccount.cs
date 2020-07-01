using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_3
{
    public class SpecialBankAccount : BankAccount, IPrintableBankAccount
    {
        /*
           A Conta Especial possui um atributo limite que dá credito a mais para o correntista caso ele precise sacar mais que o saldo. 
           Neste caso, o saldo pode ficar negativo desde que não ultrapasse o limite. Contudo isso não pode acontecer na classe Conta Corrente.
         */

        private decimal _limit;

        public SpecialBankAccount(int accountNumber, decimal limit) : base(accountNumber)
        {
            if (limit < 0)
            {
                throw new Exception("Valor não permitido para limite.");
            }

            _limit = limit;
        }

        public override void Deposit(decimal value)
        {
            if (value <= 0)
            {
                throw new Exception("Valor não permitido para depósito.");
            }

            Balance += value;
        }

        public override void Withdraw(decimal value)
        {
            if (value <= 0 || (Balance - value) < -_limit)
            {
                throw new Exception("Valor não disponível pra saque.");
            }

            Balance -= value;
        }

        public override string GetAccountData()
            => $"{base.GetAccountData()}, Limite adicional Conta: {_limit:C}, Saldo disponível para Saque: {((Balance + _limit) == 0 ? 0M : (Balance + _limit)):C}";
    }
}
