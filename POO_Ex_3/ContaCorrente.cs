using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_3
{
    class ContaCorrente : ContaBancaria, IImprimivel
    {
        /*
         A Conta Corrente possui um atributo taxaDeOperação que é descontado sempre que um saque e um depósito são feitos.
         */
        private double _taxaDeOperacao;

        public ContaCorrente(int numeroDaConta, double taxaDeOperacao) : base(numeroDaConta)
        {
            _taxaDeOperacao = taxaDeOperacao;
        }

        public override void Depositar(double valor)
        {
            valor -= _taxaDeOperacao;
            Saldo += valor;
        }

        public override void Sacar(double valor)
        {
            valor += _taxaDeOperacao;

            if(Math.Round(valor, 2) > Math.Round(Saldo, 2))
            {
                throw new Exception("Valor não disponível pra saque.");
            }

            Saldo -= valor;
        }

        public void MostrarDados()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Taxa de Operação: {_taxaDeOperacao}, Saldo disponível para Saque: {(Math.Round(Saldo - _taxaDeOperacao, 2) <= 0 ? 0d : Math.Round(Saldo - _taxaDeOperacao, 2)).ToString("C2")}";
        }
    }
}
