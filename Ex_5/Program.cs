using System;

namespace Ex_5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Crie uma aplicação que calcule a fórmula de Bhaskara.

            Receba os valores a,b,c.
            Imprima os resultados R1 e R2.
            Use a biblioteca MATH.
             */
            Console.WriteLine("Exercício 5: Crie uma aplicação que calcule a fórmula de Bhaskara." + Environment.NewLine);

            Console.WriteLine("Digite um valor pra A: ");
            float.TryParse(Console.ReadLine(), out float valorA);

            Console.WriteLine("Digite um valor pra B: ");
            float.TryParse(Console.ReadLine(), out float valorB);

            Console.WriteLine("Digite um valor pra C: ");
            float.TryParse(Console.ReadLine(), out float valorC);

            var delta = Math.Pow(valorB, 2) - (4 * valorA * valorC);

            Console.WriteLine();

            if (delta > 0)
            {
                var r1 = (-valorB + Math.Sqrt(delta)) / (2 * valorA);
                var r2 = (-valorB - Math.Sqrt(delta)) / (2 * valorA);

                Console.WriteLine($"Valor R1: {r1}");
                Console.WriteLine($"Valor R2: {r2}");
            }
            else
            {
                Console.WriteLine($"Delta negativo: {delta}");
            }
        }
    }
}
