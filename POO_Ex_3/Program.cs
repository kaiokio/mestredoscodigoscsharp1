using System;
using System.Collections.Generic;
using System.Linq;

namespace POO_Ex_3
{
    class Program
    {
        private const int INSERIR_CONTA_CORRENTE = 1;
        private const int INSERIR_CONTA_ESPECIAL = 2;
        private const int DEPOSITAR_DE_CONTA = 3;
        private const int SACAR_DE_CONTA = 4;
        private const int MOSTRAR_DADOS_TODAS_CONTAS = 5;
        private const int OPCAO_SAIR = 0;

        private static List<ContaBancaria> listContas = new List<ContaBancaria>();

        static void Main(string[] args)
        {
            /*
             Faça uma aplicação bancaria.
                Crie uma classe abstrata Conta Bancaria que contém como atributos, numero da conta e o saldo, e como métodos abstratos sacar e depositar que recebem um parâmetro do tipo double.
                Crie as classes Conta Corrente e Conta Especial que herdam da Conta Bancaria.
                A Conta Corrente possui um atributo taxaDeOperação que é descontado sempre que um saque e um depósito são feitos.
                A Conta Especial possui um atributo limite que dá credito a mais para o correntista caso ele precise sacar mais que o saldo. Neste caso, o saldo pode ficar negativo desde que não ultrapasse o limite. Contudo isso não pode acontecer na classe Conta Corrente.
                Crie uma interface Imprimível que declara um método MostrarDados, implemente em ambas contas e imprima os dados em cada uma.
                Via console, abra 2 contas de cada tipo execute todas as operações.
             */

            Console.WriteLine("POO - Exercício 3 - Faça uma aplicação bancaria.");

            int opcaoMenu;

            do
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" 1 - Inserir nova Conta Corrente.");
                Console.WriteLine(" 2 - Inserir nova Conta Especial.");
                Console.WriteLine(" 3 - Depositar em Conta existente.");
                Console.WriteLine(" 4 - Sacar de Conta existente.");
                Console.WriteLine(" 5 - Imprimir dados de todas contas.");
                Console.WriteLine(" 0  - SAIR");

                int.TryParse(Console.ReadLine(), out opcaoMenu);

                try
                {
                    switch (opcaoMenu)
                    {
                        case INSERIR_CONTA_CORRENTE:
                            InserirContaCorrente();
                            break;
                        case INSERIR_CONTA_ESPECIAL:
                            InserirContaEspecial();
                            break;
                        case DEPOSITAR_DE_CONTA:
                            Depositar();
                            break;
                        case SACAR_DE_CONTA:
                            Sacar();
                            break;
                        case MOSTRAR_DADOS_TODAS_CONTAS:
                            MostrarDadosTodasContas();
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                }
            }
            while (opcaoMenu != OPCAO_SAIR);
        }

        static void InserirContaCorrente()
        {
            Console.WriteLine();
            Console.WriteLine("Adicionando nova Conta Corrente:"+Environment.NewLine);
            Console.WriteLine("Digite o número da Conta:");
            int.TryParse(Console.ReadLine(), out int numeroConta);
            Console.WriteLine("Digite o valor da taxa de operação (separado por vírgula se for decimal):");
            double.TryParse(Console.ReadLine(), out double taxaOperacao);

            if(ContaExiste(numeroConta))
            {
                throw new ArgumentException($"Número da Conta {numeroConta} já existe.");
            }

            listContas.Add(new ContaCorrente(numeroConta, taxaOperacao));
        }

        static void InserirContaEspecial()
        {
            Console.WriteLine();
            Console.WriteLine("Adicionando nova Conta Especial:" + Environment.NewLine);
            Console.WriteLine("Digite o número da Conta:");
            int.TryParse(Console.ReadLine(), out int numeroConta);
            Console.WriteLine("Digite o valor do limite (separado por vírgula se for decimal):");
            double.TryParse(Console.ReadLine(), out double limite);

            if (ContaExiste(numeroConta))
            {
                throw new ArgumentException($"Número da Conta {numeroConta} já existe.");
            }

            listContas.Add(new ContaEspecial(numeroConta, limite));
        }

        static bool ContaExiste(int numeroConta) => listContas.Any(c => c.NumeroDaConta == numeroConta);

        static void Depositar()
        {
            Console.WriteLine();
            Console.WriteLine("Realizar Depósito:" + Environment.NewLine);
            Console.WriteLine("Digite o número da Conta:");
            int.TryParse(Console.ReadLine(), out int numeroConta);
            Console.WriteLine("Digite o valor do Depósito (separado por vírgula se for decimal):");
            double.TryParse(Console.ReadLine(), out double deposito);

            var conta = listContas.Find(c => c.NumeroDaConta == numeroConta);

            if(conta == null)
            {
                throw new ArgumentException("Conta não encontrada");
            }

            conta.Depositar(deposito);
        }

        static void Sacar()
        {
            Console.WriteLine();
            Console.WriteLine("Realizar Saque:" + Environment.NewLine);
            Console.WriteLine("Digite o número da Conta:");
            int.TryParse(Console.ReadLine(), out int numeroConta);
            Console.WriteLine("Digite o valor do Saque (separado por vírgula se for decimal):");
            double.TryParse(Console.ReadLine(), out double saque);

            var conta = listContas.Find(c => c.NumeroDaConta == numeroConta);

            if (conta == null)
            {
                throw new ArgumentException("Conta não encontrada");
            }

            conta.Sacar(saque);
        }

        static void MostrarDadosTodasContas()
        {
            Console.WriteLine();
            listContas.ForEach(c => ((IImprimivel)c).MostrarDados());
        }
    }
}
