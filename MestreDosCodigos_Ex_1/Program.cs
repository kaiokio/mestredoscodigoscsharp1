using Commom.Extensions;
using System;

namespace Ex_1
{
    class Program
    {
        private const int OPCAO_SOMAR = 1;
        private const int OPCAO_SUBTRAIR = 2;
        private const int OPCAO_DIVIDIR = 3;
        private const int OPCAO_MULTIPLICAR = 4;
        private const int OPCAO_PAR_OU_IMPAR = 5;
        private const int OPCAO_SAIR = 0;

        static void Main(string[] args)
        {
            /*
                1-Crie uma aplicação, que receba os valores A e B. Mostre de forma simples, como utilizar variáveis e manipular dados.

                Some esses 2 valores;
                Faça uma subtração do valor A - B;
                Divida o valor B por A;
                Multiplique o valor A por B;
                Imprima os valores de entrada, informado se o número é par ou impar;
                Imprima todos os resultados no console, de forma que o usuário escolha a ação desejada.

              */

            Console.WriteLine("Exercício 1: Crie uma aplicação, que receba os valores A e B. Mostre de forma simples, como utilizar variáveis e manipular dados." + Environment.NewLine);

            Console.WriteLine("Digite um valor inteiro pra A: ");
            int.TryParse(Console.ReadLine(), out int valorA);

            Console.WriteLine("Digite um valor inteiro pra B: ");
            int.TryParse(Console.ReadLine(), out int valorB);

            int opcaoMenu;

            do
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Escolha uma das opções abaixo e pressione ENTER:" + Environment.NewLine);
                Console.WriteLine("  1 - Some esses 2 valores");
                Console.WriteLine("  2 - Faça uma subtração do valor A -B");
                Console.WriteLine("  3 - Divida o valor B por A");
                Console.WriteLine("  4 - Multiplique o valor A por B");
                Console.WriteLine("  5 - Imprima os valores de entrada, informado se o número é par ou impar");
                Console.WriteLine("  0 - Sair");

                int.TryParse(Console.ReadLine(), out opcaoMenu);

                Console.WriteLine(Environment.NewLine);
                
                switch (opcaoMenu)
                {
                    case OPCAO_SOMAR:
                        Imprimir("Soma", valorA, valorB, Somar(valorA, valorB).ToString());
                        break;
                    case OPCAO_SUBTRAIR:
                        Imprimir("Subtração", valorA, valorB, Subtrair(valorA, valorB).ToString());
                        break;
                    case OPCAO_DIVIDIR:
                        Imprimir("Divisão", valorA, valorB, Dividir(valorA, valorB).ToString());
                        break;
                    case OPCAO_MULTIPLICAR:
                        Imprimir("Multiplicação", valorA, valorB, Multiplicar(valorA, valorB).ToString());
                        break;
                    case OPCAO_PAR_OU_IMPAR:
                        Console.WriteLine($"Valor de A: {valorA}. Este valor é: {(valorA.IsPar() ? "PAR" : "IMPAR")}  ");
                        Console.WriteLine($"Valor de B: {valorB}. Este valor é: {(valorB.IsPar() ? "PAR" : "IMPAR")}  ");
                        break;
                }
            }
            while (opcaoMenu != OPCAO_SAIR);
        }

        private static int Somar(int a, int b) => a + b;
        private static int Subtrair(int a, int b) => a - b;
        private static float Dividir(int a, int b) => b / (float)a;
        private static int Multiplicar(int a, int b) => a * b;
        private static void Imprimir(string operacao, int valorA, int valorB, string valorOperacao) => Console.WriteLine($"Operação de {operacao}. Valores das variáveis => A: {valorA}, B: {valorB}. Valor da operação: {valorOperacao}");
    }
}
