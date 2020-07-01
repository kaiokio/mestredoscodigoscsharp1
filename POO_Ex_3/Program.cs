using Commom.Culture;
using Commom.Extensions;
using Commom.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POO_Ex_3
{
    class Program
    {
        private const int INSERT_NORMAL_ACCOUNT = 1;
        private const int INSERT_SPECIAL_ACCOUNT = 2;
        private const int DEPOSIT = 3;
        private const int WITHDRAW = 4;
        private const int SHOW_DATA_FOR_ALL_ACCOUNTS = 5;
        private const int EXIT = 0;

        private static List<BankAccount> _accounts = new List<BankAccount>();

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

            ProgramCulture.ChangeCurrentCulture("pt-BR");
            Console.WriteLine("POO - Exercício 3 - Faça uma aplicação bancaria.");

            int menuOption;

            do
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" 1 - Inserir nova Conta Corrente.");
                Console.WriteLine(" 2 - Inserir nova Conta Especial.");
                Console.WriteLine(" 3 - Depositar em Conta existente.");
                Console.WriteLine(" 4 - Sacar de Conta existente.");
                Console.WriteLine(" 5 - Imprimir dados de todas contas.");
                Console.WriteLine(" 0 - SAIR");

                ConsoleHelper.ReadPositiveInt("Digite uma opção do Menu", out menuOption);

                try
                {
                    switch (menuOption)
                    {
                        case INSERT_NORMAL_ACCOUNT:
                            InsertNormalAccount();
                            break;
                        case INSERT_SPECIAL_ACCOUNT:
                            InsertSpecialAccount();
                            break;
                        case DEPOSIT:
                            Deposit();
                            break;
                        case WITHDRAW:
                            Withdraw();
                            break;
                        case SHOW_DATA_FOR_ALL_ACCOUNTS:
                            ShowDataForAllAccounts();
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                }
            }
            while (menuOption != EXIT);
        }

        static void InsertNormalAccount()
        {
            Console.WriteLine();
            Console.WriteLine("Adicionando nova Conta Corrente:" + Environment.NewLine);
            ConsoleHelper.ReadPositiveInt("Digite o número da Conta:", out int accountNumber);
            Console.WriteLine();

            if (ExistsAccount(accountNumber))
            {
                throw new ArgumentException($"Número da Conta {accountNumber} já existe.");
            }

            ConsoleHelper.ReadPositiveOrZeroDecimal("Digite o valor da taxa de operação (separado por vírgula se for decimal):", out decimal operationRate);
            
            _accounts.Add(new NormalBankAccount(accountNumber, operationRate));
        }

        static void InsertSpecialAccount()
        {
            Console.WriteLine();
            Console.WriteLine("Adicionando nova Conta Especial:" + Environment.NewLine);
            ConsoleHelper.ReadPositiveInt("Digite o número da Conta:", out int accountNumber);
            Console.WriteLine();

            if (ExistsAccount(accountNumber))
            {
                throw new ArgumentException($"Número da Conta {accountNumber} já existe.");
            }

            ConsoleHelper.ReadPositiveOrZeroDecimal("Digite o valor do limite (separado por vírgula se for decimal):", out decimal limit);

            _accounts.Add(new SpecialBankAccount(accountNumber, limit));
        }

        static bool ExistsAccount(int accountNumber) => _accounts.Any(c => c.AccountNumber.Equals(accountNumber));

        static void Deposit()
        {
            Console.WriteLine();
            Console.WriteLine("Realizar Depósito:" + Environment.NewLine);

            ConsoleHelper.ReadPositiveInt("Digite o número da Conta:", out int accountNumber);
            Console.WriteLine();
            ConsoleHelper.ReadPositiveOrZeroDecimal("Digite o valor do Depósito (separado por vírgula se for decimal):", out decimal depositValue);

            var account = _accounts.Find(c => c.AccountNumber == accountNumber);

            if (account == null)
            {
                throw new ArgumentException("Conta não encontrada");
            }

            account.Deposit(depositValue);
        }

        static void Withdraw()
        {
            Console.WriteLine();
            Console.WriteLine("Realizar Saque:" + Environment.NewLine);

            ConsoleHelper.ReadPositiveInt("Digite o número da Conta:", out int accountNumber);
            Console.WriteLine();
            ConsoleHelper.ReadPositiveOrZeroDecimal("Digite o valor do Saque (separado por vírgula se for decimal):", out decimal withdraw);
            
            var account = _accounts.Find(c => c.AccountNumber == accountNumber);

            if (account == null)
            {
                throw new ArgumentException("Conta não encontrada");
            }

            account.Withdraw(withdraw);
        }

        static void ShowDataForAllAccounts()
        {
            Console.WriteLine();
            _accounts.ForEach(c => ((IPrintableBankAccount)c).ShowAccountData());
        }
    }
}
