using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_4
{
    class Televisao : IComandosTelevisao
    {
        private const int VOLUME_MAXIMO = 100;
        private const int VOLUME_MINIMO = 0;

        private const int CANAL_MAXIMO = 13;
        private const int CANAL_MINIMO = 1;


        public int Volume { get; private set; }
        public int Canal { get; private set; }

        public void AumentarVolume()
        {
            if (Volume < VOLUME_MAXIMO)
            {
                Volume++;
            }
        }
        
        public void DiminuirVolume()
        {
            if (Volume > VOLUME_MINIMO)
            {
                Volume--;
            }
        }

        public void SubirCanal() => TrocarCanal(Canal + 1);

        public void DescerCanal() => TrocarCanal(Canal - 1);

        public void TrocarCanal(int canal)
        {
            if (canal > CANAL_MAXIMO)
            {
                canal = CANAL_MINIMO;
            }
            else if (canal < CANAL_MINIMO)
            {
                canal = CANAL_MAXIMO;
            }

            Canal = canal;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"Televisão está no canal {Canal} com volume {Volume}";
        }
    }
}
