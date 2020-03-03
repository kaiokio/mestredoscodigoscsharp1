using Bogus;
using System;
using System.Collections.Generic;

namespace POO_Ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Crie uma classe para representar uma pessoa
                Crie os atributos privados de nome, data de nascimento e altura.
                Crie os métodos públicos necessários para sets e gets e também um método para imprimir todos dados de uma pessoa.
                Crie um método para calcular a idade da pessoa.
                Imprima os dados via console.
             */

            Console.WriteLine("POO - Exercício 2 - Crie uma classe para representar uma pessoa." + Environment.NewLine);

            var listPessoas = new List<Pessoa> 
            {
                GenerateRandomPessoa(), GenerateRandomPessoa(), GenerateRandomPessoa(), GenerateRandomPessoa(), GenerateRandomPessoa(), GenerateRandomPessoa()
            };

            listPessoas.ForEach(p => p.ImprimirDadosPessoa());
        }

        static Pessoa GenerateRandomPessoa()
        {
            var faker = new Faker();

            return new Pessoa { 
                Nome = faker.Person.FullName,
                DataNascimento = faker.Person.DateOfBirth,
                Altura = faker.Random.Decimal(0.5M, 2.15M)
            };
        }
    }
}
