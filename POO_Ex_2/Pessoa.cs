using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_2
{
    class Pessoa
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private DateTime _dataNascimento;

        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; }
        }

        private decimal _altura;

        public decimal Altura
        {
            get { return _altura; }
            set { _altura = value; }
        }

        public void ImprimirDadosPessoa()
        {
            Console.WriteLine(this.ToString());
        }

        public int Idade()
        {
            var dataAtual = DateTime.Today;
            var idade = dataAtual.Year - _dataNascimento.Year;

            if (_dataNascimento.Date > dataAtual.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }

        public override string ToString()
        {
            return $"Nome: {_nome}, Data de Nascimento: {_dataNascimento.ToString("dd/MM/yyyy")}, Altura: {_altura.ToString("N2")}, Idade: {Idade()}";
        }
    }
}
