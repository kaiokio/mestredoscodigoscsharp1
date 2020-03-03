using Commom.Extensions;
using System;
using System.Linq;

namespace Ex_7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Faça uma aplicação ler 4 números inteiros e calcular a soma dos que forem pares.
             */
            Console.WriteLine("Exercício 7: Faça uma aplicação ler 4 números inteiros e calcular a soma dos que forem pares." + Environment.NewLine);

            const int QUANTIDADE_DE_VALORES = 4;
            var valores = new int[QUANTIDADE_DE_VALORES];
            for (int i = 0; i < QUANTIDADE_DE_VALORES; i++)
            {
                Console.WriteLine("Digite um valor inteiro: ");
                int.TryParse(Console.ReadLine(), out int valor);
                valores[i] = valor;
            }

            Console.WriteLine($"Soma dos valores pares: {valores.Where(v => v.IsPar()).Sum()}");
        }
    }
}
