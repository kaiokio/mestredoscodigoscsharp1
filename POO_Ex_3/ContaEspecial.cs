using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_3
{
    public class ContaEspecial : ContaBancaria, IImprimivel
    {
        /*
           A Conta Especial possui um atributo limite que dá credito a mais para o correntista caso ele precise sacar mais que o saldo. 
           Neste caso, o saldo pode ficar negativo desde que não ultrapasse o limite. Contudo isso não pode acontecer na classe Conta Corrente.
         */

        private double _limite;

        public ContaEspecial(int numeroDaConta, double limite) : base(numeroDaConta)
        {
            _limite = limite;
        }

        public override void Depositar(double valor)
        {
            Saldo += valor;
        }

        public override void Sacar(double valor)
        {
            if (Math.Round(Saldo - valor, 2) < Math.Round(-_limite, 2))
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
            return $"{base.ToString()}, Limite adicional Conta: {_limite.ToString("C2")}, Saldo disponível para Saque: {(Math.Round(Saldo + _limite, 2) == 0 ? 0d : Math.Round(Saldo + _limite, 2)).ToString("C2")}";
        }
    }
}
