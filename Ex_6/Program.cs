using System;

namespace Ex_6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Crie uma aplicação, que demonstre a diferença entre REF e OUT.
             */

            Console.WriteLine("Exercício 6: Crie uma aplicação, que demonstre a diferença entre REF e OUT." + Environment.NewLine);

            Console.WriteLine("Digite um valor inteiro pra REF: ");
            int.TryParse(Console.ReadLine(), out int valorRef);

            Console.WriteLine("Digite um valor inteiro pra OUT: ");
            int.TryParse(Console.ReadLine(), out int valorOut);

            Console.WriteLine();
            Console.WriteLine("Ambos os valores serão multiplicados por 2." + Environment.NewLine);

            MultiplicarValorREFPor2(ref valorRef);
            MultiplicarValorOUTPor2(out valorOut);

            Console.WriteLine($"Valor REF: {valorRef}\n No caso do tipo de modificador REF, entende-se que: \n  1 - O valor já está definido e\n  2 - O método pode ler e modificá-la."+Environment.NewLine);
            Console.WriteLine($"Valor OUT: {valorOut}\n No caso do tipo de modificador OUT, entende-se que: \n  1 - O Valor NÃO está definido e não pode ser lido pelo método até que esteja definido." +
                $"\n  2 - O método deve setar o valor antes de retornar." +
                $"\n\n Este tipo de modificador é bastante utilizado quando se quer fazer um único método retornar mais de um parâmetro " +
                $"(com bastante cuidado ao utilizar, como é no caso do int.TryParse, que retorna um booleano se a conversão foi sucesso, porém como OUT retorna o valor da conversão.");

        }

        static void MultiplicarValorREFPor2(ref int valor)
        {
            valor *= 2;
        }

        static void MultiplicarValorOUTPor2(out int valor)
        {
            valor = 0;
            valor *= 2;
        }
    }
}
