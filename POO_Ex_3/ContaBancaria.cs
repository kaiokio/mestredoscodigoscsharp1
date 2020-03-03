using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_3
{
    abstract class ContaBancaria
    {
        /*
            Crie uma classe abstrata Conta Bancaria que contém como atributos, numero da conta e o saldo, e como métodos abstratos sacar e depositar que recebem um parâmetro do tipo double.
        */

        public int NumeroDaConta { get; protected set; }
        public double Saldo { get; protected set; }

        protected ContaBancaria(int numeroDaConta)
        {
            NumeroDaConta = numeroDaConta;
        }

        public abstract void Sacar(double valor);
        public abstract void Depositar(double valor);

        public override string ToString()
        {
            return $"Dados da Conta: Numero da Conta: {NumeroDaConta}, Saldo: {(Math.Round(Saldo, 2) == 0 ? 0d : Math.Round(Saldo, 2)).ToString("C2")}";
        }
    }
}
