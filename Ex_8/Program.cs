using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_8
{
    class Program
    {
        private const int OPCAO_SAIR = 0;

        static void Main(string[] args)
        {
            /*
             Faça uma aplicação ler N valores decimais, imprima os valores em ordem crescente e decrescente.
             */
            Console.WriteLine("Exercício 8: Faça uma aplicação ler N valores decimais, imprima os valores em ordem crescente e decrescente." + Environment.NewLine);

            var listValores = new List<decimal>();

            Console.WriteLine("Digite um novo valor decimal (0 para sair): " + Environment.NewLine);
            decimal.TryParse(Console.ReadLine(), out decimal valor);
            
            while (valor != OPCAO_SAIR)
            {
                listValores.Add(valor);

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Digite um novo valor decimal (0 para sair): " + Environment.NewLine);

                decimal.TryParse(Console.ReadLine(), out valor);
            }

            Console.WriteLine($"Valores em ordem Crescente: {string.Join(" | ", listValores.OrderBy(v => v))}");
            Console.WriteLine($"Valores em ordem Decrescente: {string.Join(" | ", listValores.OrderByDescending(v => v))}");
        }
    }
}
