using System;

namespace POO_Ex_4
{
    class Program
    {
        private const int AUMENTAR_VOLUME = 1;
        private const int DIMINUIR_VOLUME = 2;
        private const int SUBIR_CANAL = 3;
        private const int DESCER_CANAL = 4;
        private const int TROCAR_CANAL_ESPECIFICO = 5;
        private const int EXIBIR_INFORMACOES = 6;
        private const int OPCAO_SAIR = 0;

        static void Main(string[] args)
        {
            /*
             Crie uma classe Televisão e uma classe ControleRemoto que pode controlar o volume e trocar os canais da televisão. O controle de volume permite:
                Aumentar ou diminuir a potência do volume de som em uma unidade de cada vez.
                Aumentar e diminuir o número do canal em uma unidade.
                Trocar para um canal indicado.
                Consultar o valor do volume de som e o canal selecionado.
                Imprima os dados via console.
             */
            Console.WriteLine("POO - Exercício 4 - Crie uma classe Televisão e uma classe ControleRemoto que pode controlar o volume e trocar os canais da televisão.");

            int opcaoMenu;
            var televisao = new Televisao();
            var controleRemoto = new ControleRemoto(televisao);

            do
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" 1 - Aumentar Volume.");
                Console.WriteLine(" 2 - Diminuir Volume.");
                Console.WriteLine(" 3 - Subir Canal.");
                Console.WriteLine(" 4 - Descer Canal.");
                Console.WriteLine(" 5 - Trocar para Canal específico.");
                Console.WriteLine(" 6 - Informações TV.");
                Console.WriteLine(" 0 - SAIR");

                int.TryParse(Console.ReadLine(), out opcaoMenu);

                try
                {
                    switch (opcaoMenu)
                    {
                        case AUMENTAR_VOLUME:
                            controleRemoto.AumentarVolume();
                            break;
                        case DIMINUIR_VOLUME:
                            controleRemoto.DiminuirVolume();
                            break;
                        case SUBIR_CANAL:
                            controleRemoto.SubirCanal();
                            break;
                        case DESCER_CANAL:
                            controleRemoto.DescerCanal();
                            break;
                        case TROCAR_CANAL_ESPECIFICO:

                            Console.WriteLine("    Digite o canal:");
                            int.TryParse(Console.ReadLine(), out int canal);
                            controleRemoto.TrocarCanal(canal);
                            break;
                        case EXIBIR_INFORMACOES:
                            controleRemoto.ExibirInformacoes();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                }
            }
            while (opcaoMenu != OPCAO_SAIR);
        }
    }
}
