using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_4
{
    interface IComandosTelevisao
    {
        void AumentarVolume();
        void DiminuirVolume();
        void SubirCanal();
        void DescerCanal();
        void TrocarCanal(int canal);
        void ExibirInformacoes();
    }
}
