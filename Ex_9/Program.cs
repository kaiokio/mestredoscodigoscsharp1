using Commom.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_9
{
    class Program
    {
        private const int INSIRA_UM_NUMERO_NO_INICIO_DA_LISTA = 1;
        private const int INSIRA_UM_NUMERO_NO_FINAL_DA_LISTA = 2;
        private const int REMOVA_O_PRIMEIRO_NUMERO = 3;
        private const int REMOVA_O_ULTIMO_NUMERO = 4;
        private const int TRANSFORME_TODOS_OS_NUMERO_DA_LISTA_EM_UM_ARRAY = 5;
        private const int IMPRIMIR_TODOS_OS_NUMEROS_DA_LISTA = 6;
        private const int IMPRIMIR_TODOS_OS_NUMEROS_DA_LISTA_NA_ORDEM_CRESCENTE = 7;
        private const int IMPRIMIR_TODOS_OS_NUMEROS_DA_LISTA_NA_ORDEM_DECRESCENTE = 8;
        private const int IMPRIMIR_APENAS_O_PRIMEIRO_NUMERO_DA_LISTA = 9;
        private const int IMPRIMIR_APENAS_O_ULTIMO_NUMERO_DA_LISTA = 10;
        private const int IMPRIMIR_APENAS_OS_NUMERO_PARES = 11;
        private const int IMPRIMIR_APENAS_O_NUMERO_INFORMADO = 12;
        private const int OPCAO_SAIR = 0;


        private static List<int> _listaValores = new List<int>();

        static void Main(string[] args)
        {
            /*
             Utilizando a biblioteca LINQ crie no console e execute:
                Crie uma lista que receba inteiros.
                Imprimir todos os números da lista.
                Imprimir todos os números da lista na ordem crescente.
                Imprimir todos os números da lista na ordem decrescente.
                Imprima apenas o primeiro número da lista
                Imprima apenas o ultimo número da lista
                Insira um numero no inicio da lista.
                Insira um numero no final da lista.
                Remova o primeiro número .
                Remova o ultimo número .
                Retorne apenas os número pares.
                Retorne apenas o número informado.
                Transforme todos os numero da lista em um array.
             */

            Console.WriteLine("Exercício 9: Utilizando a biblioteca LINQ crie no console e execute:");


            int opcaoMenu;

            do
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" 1 - Insira um numero no inicio da lista.");
                Console.WriteLine(" 2 - Insira um numero no final da lista.");
                Console.WriteLine(" 3 - Remova o primeiro número.");
                Console.WriteLine(" 4 - Remova o ultimo número.");
                Console.WriteLine(" 5 - Transforme todos os numero da lista em um array.");
                Console.WriteLine(" 6 - Imprimir todos os números da lista.");
                Console.WriteLine(" 7 - Imprimir todos os números da lista na ordem crescente.");
                Console.WriteLine(" 8 - Imprimir todos os números da lista na ordem decrescente.");
                Console.WriteLine(" 9 - Imprimir apenas o primeiro número da lista.");
                Console.WriteLine(" 10 - Imprimir apenas o ultimo número da lista.");
                Console.WriteLine(" 11 - Imprimir apenas os número pares.");
                Console.WriteLine(" 12 - Imprimir apenas o número informado.");
                Console.WriteLine(" 0  - SAIR");
                
                int.TryParse(Console.ReadLine(), out opcaoMenu);

                switch (opcaoMenu)
                {
                    case INSIRA_UM_NUMERO_NO_INICIO_DA_LISTA:
                        InserirNumeroInicioDaLista();
                        break;
                    case INSIRA_UM_NUMERO_NO_FINAL_DA_LISTA:
                        InserirNumeroFimDaLista();
                        break;
                    case REMOVA_O_PRIMEIRO_NUMERO:
                        RemoverOPrimeiroValorDaLista();
                        break;
                    case REMOVA_O_ULTIMO_NUMERO:
                        RemoverOUltimoValorDaLista();
                        break;
                    case TRANSFORME_TODOS_OS_NUMERO_DA_LISTA_EM_UM_ARRAY:
                        TransformarListaNumArrayEImprimir();
                        break;
                    case IMPRIMIR_TODOS_OS_NUMEROS_DA_LISTA:
                        Imprimir(_listaValores);
                        break;
                    case IMPRIMIR_TODOS_OS_NUMEROS_DA_LISTA_NA_ORDEM_CRESCENTE:
                        Imprimir(_listaValores.OrderBy(v => v).ToList());
                        break;
                    case IMPRIMIR_TODOS_OS_NUMEROS_DA_LISTA_NA_ORDEM_DECRESCENTE:
                        Imprimir(_listaValores.OrderByDescending(v => v).ToList());
                        break;
                    case IMPRIMIR_APENAS_O_PRIMEIRO_NUMERO_DA_LISTA:
                        Imprimir(_listaValores.First());
                        break;
                    case IMPRIMIR_APENAS_O_ULTIMO_NUMERO_DA_LISTA:
                        Imprimir(_listaValores.Last());
                        break;
                    case IMPRIMIR_APENAS_OS_NUMERO_PARES:
                        Imprimir(_listaValores.Where(v => v.IsPar()).ToList());
                        break;
                    case IMPRIMIR_APENAS_O_NUMERO_INFORMADO:
                        ImprimirUmNumeroEspecifico();
                        break;
                }
            }
            while (opcaoMenu != OPCAO_SAIR);
        }

        private static void InserirNumeroInicioDaLista()
        {
            Console.WriteLine();
            Console.WriteLine("  Digite um número inteiro:");
            int.TryParse(Console.ReadLine(), out int valor);

            _listaValores.Insert(0, valor);
        }

        private static void InserirNumeroFimDaLista()
        {
            Console.WriteLine();
            Console.WriteLine("  Digite um número inteiro:");
            int.TryParse(Console.ReadLine(), out int valor);

            _listaValores.Add(valor);
        }

        private static void RemoverOPrimeiroValorDaLista()
        {
            Console.WriteLine();
            Console.WriteLine($" {_listaValores.First()} Removido.");
            _listaValores.RemoveAt(0);
        }
        private static void RemoverOUltimoValorDaLista()
        {
            Console.WriteLine();
            Console.WriteLine($" {_listaValores.Last()} Removido.");
            _listaValores.RemoveAt(_listaValores.Count - 1);
        }

        private static void Imprimir(List<int> lista)
        {
            Console.WriteLine();
            Console.WriteLine("  Impressão de valores:");
            lista.ForEach(v => Console.WriteLine(v));
        }

        private static void Imprimir(int valor)
        {
            Console.WriteLine();
            Console.WriteLine("  Impressão de um único valor:");
            Console.WriteLine(valor);
        }

        private static void ImprimirUmNumeroEspecifico()
        {
            Console.WriteLine();
            Console.WriteLine("  Digite um número inteiro para exibir:");
            int.TryParse(Console.ReadLine(), out int valor);

            Console.WriteLine();
            if (_listaValores.Contains(valor))
            {
                Console.WriteLine("  Impressão do valor informado:");
                _listaValores.Where(v => v == valor).ToList().ForEach(v => Console.WriteLine(v));
            }
            else
            {
                Console.WriteLine("  Valor não encontrado para imprimir.");
            }
        }

        private static void TransformarListaNumArrayEImprimir()
        {
            var array = _listaValores.ToArray();

            Console.WriteLine();
            Console.WriteLine("  Impressão dos valores do Array convertido:");
            foreach (var valor in array)
            {
                Console.WriteLine($"    {valor}");
            }
        }
    }
}
