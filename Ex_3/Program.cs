using System;
using System.Collections.Generic;

namespace Ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Faça uma aplicação que imprima todos os múltiplos de 3, entre 1 e 100. Utilize a repetição while.
             */

            Console.WriteLine("Exercício 3 - Faça uma aplicação que imprima todos os múltiplos de 3, entre 1 e 100. Utilize a repetição while." + Environment.NewLine);

            CalcularEImprimirMultiplosDe3(1, 100);
        }

        private static void CalcularEImprimirMultiplosDe3(int inicio, int fim)
        {
            Console.WriteLine($"Múltiplos de 3: ");
            var multiplosDe3 = new List<int>();

            while(inicio <= fim)
            {
                if(inicio % 3 == 0)
                {
                    multiplosDe3.Add(inicio);
                }

                inicio++;
            }

            Console.WriteLine(string.Join(", ", multiplosDe3));
        }
    }
}
