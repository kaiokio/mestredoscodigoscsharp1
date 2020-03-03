using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex_4
{
    class Program
    {
        private const int OPCAO_NOVO = 1;
        private const int OPCAO_NOTA_MAIOR_7 = 2;
        private const int OPCAO_SAIR = 0;
        private static IList<Aluno> alunos = new List<Aluno>();

        static void Main(string[] args)
        {
            /*
             Faça uma aplicação que receba N alunos com suas respectivas notas. Use foreach para estrutura de repetição.

                Crie um objeto alunos
                Armazene os alunos em uma lista.
                Imprima todos os alunos com medias superiores a 7.
             */

            Console.WriteLine("Exercício 4 - Faça uma aplicação que receba N alunos com suas respectivas notas. Use foreach para estrutura de repetição." + Environment.NewLine);

            int opcaoMenu;

            do
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Escolha uma das opções abaixo e pressione ENTER. (Números decimais devem ser separados por vírgula)" + Environment.NewLine);
                Console.WriteLine("  1 - Cadastrar Novo Aluno");
                Console.WriteLine("  2 - Imprimir Alunos com médias superiores a 7");
                Console.WriteLine("  0 - Sair");

                int.TryParse(Console.ReadLine(), out opcaoMenu);

                Console.WriteLine(Environment.NewLine);

                switch (opcaoMenu)
                {
                    case OPCAO_NOVO:
                        CadastrarNovoAluno();
                        break;
                    case OPCAO_NOTA_MAIOR_7:
                        ImprimirAlunosComMediaMaiorQue7();
                        break;
                }
            }
            while (opcaoMenu != OPCAO_SAIR);
        }

        private static void CadastrarNovoAluno()
        {
            var aluno = new Aluno();

            Console.WriteLine("Digite o nome do Aluno: ");
            aluno.Nome = Console.ReadLine();

            string valorDigitado;


            Console.WriteLine("Digite uma Nota para adicionar: (STOP para parar)");
            valorDigitado = Console.ReadLine();
            while (valorDigitado.ToUpper() != "STOP")
            {
                decimal.TryParse(valorDigitado, out decimal nota);
                aluno.Notas.Add(nota);

                Console.WriteLine("Digite uma Nota para adicionar: (STOP para parar)");
                valorDigitado = Console.ReadLine();
            }

            alunos.Add(aluno);
        }

        private static void ImprimirAlunosComMediaMaiorQue7()
        {
            foreach (var aluno in alunos)
            {
                if(aluno.Media > 7)
                {
                    Console.WriteLine($"Aluno: {aluno.Nome}, Média: {aluno.Media}");
                }
            }
        }
    }

    class Aluno
    {
        public string Nome { get; set; }
        public IList<decimal> Notas { get; set; } = new List<decimal>();
        public decimal Media => Notas.Average(n => n);
    }
}
