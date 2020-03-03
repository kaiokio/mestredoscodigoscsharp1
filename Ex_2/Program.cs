using System;
using System.Collections.Generic;

namespace Ex_2
{
    class Program
    {
        private const int OPCAO_NOVO = 1;
        private const int OPCAO_MAIOR_SALARIO = 2;
        private const int OPCAO_MENOR_SALARIO = 3;
        private const int OPCAO_SAIR = 0;

        private static IList<Funcionario> funcionarios = new List<Funcionario>();

        static void Main(string[] args)
        {
            /*
                Crie uma aplicação que receba nome e salario de N funcionários. Utilize a repetição for e while.

                    Imprima o maior salario
                    Imprima o menor salario.
              */

            Console.WriteLine("Exercício 2 - Crie uma aplicação que receba nome e salario de N funcionários. Utilize a repetição for e while." + Environment.NewLine);

            int opcaoMenu;

            do
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Escolha uma das opções abaixo e pressione ENTER. (Números decimais devem ser separados por vírgula)" + Environment.NewLine);
                Console.WriteLine("  1 - Cadastrar Novo Funcionário");
                Console.WriteLine("  2 - Imprimir MAIOR salário (FOR)");
                Console.WriteLine("  3 - Imprimir MENOR salário (WHILE)");
                Console.WriteLine("  0 - Sair");

                int.TryParse(Console.ReadLine(), out opcaoMenu);

                Console.WriteLine(Environment.NewLine);

                switch (opcaoMenu)
                {
                    case OPCAO_NOVO:
                        CadastrarNovoFuncionario();
                        break;
                    case OPCAO_MAIOR_SALARIO:
                        var funcionarioComMaiorSalario = GetFuncionarioComMaiorSalario();
                        Console.WriteLine($"Funcionário com MAIOR salário: {funcionarioComMaiorSalario.Nome}, Valor: {funcionarioComMaiorSalario.Salario}");
                        break;
                    case OPCAO_MENOR_SALARIO:
                        var funcionarioComMenorSalario = GetFuncionarioComMenorSalario();
                        Console.WriteLine($"Funcionário com MENOR salário: {funcionarioComMenorSalario.Nome}, Valor: {funcionarioComMenorSalario.Salario}");
                        break;
                }
            }
            while (opcaoMenu != OPCAO_SAIR);
        }

        private static void CadastrarNovoFuncionario()
        {
            var funcionario = new Funcionario();

            Console.WriteLine("Digite o nome do funcionário: ");
            funcionario.Nome = Console.ReadLine();

            Console.WriteLine("Digite o valor do Salário: ");
            decimal.TryParse(Console.ReadLine(), out decimal salarioFuncionario);
            funcionario.Salario = salarioFuncionario;

            funcionarios.Add(funcionario);
        }

        private static Funcionario GetFuncionarioComMaiorSalario()
        {
            Funcionario funcionarioRetornar = null;

            for (int i = 0; i < funcionarios.Count; i++)
            {
                if(funcionarioRetornar == null || funcionarios[i].Salario > funcionarioRetornar.Salario)
                {
                    funcionarioRetornar = funcionarios[i];
                }
            }

            return funcionarioRetornar;
        }

        private static Funcionario GetFuncionarioComMenorSalario()
        {
            Funcionario funcionarioRetornar = null;

            int i = 0;
            while (i < funcionarios.Count)
            {
                if (funcionarioRetornar == null || funcionarios[i].Salario < funcionarioRetornar.Salario)
                {
                    funcionarioRetornar = funcionarios[i];
                }

                i++;
            }

            return funcionarioRetornar;
        }
    }

    class Funcionario
    {
        public string Nome { get; set; }
        public decimal Salario { get; set; }
    }
}
