using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Ex_4
{
    class ControleRemoto
    {
        private IComandosTelevisao _comandosTelevisao;

        public ControleRemoto(IComandosTelevisao comandosTelevisao)
        {
            _comandosTelevisao = comandosTelevisao;
        }

        public void AumentarVolume() => _comandosTelevisao.AumentarVolume();

        public void DiminuirVolume() => _comandosTelevisao.DiminuirVolume();

        public void SubirCanal() => _comandosTelevisao.SubirCanal();

        public void DescerCanal() => _comandosTelevisao.DescerCanal();

        public void TrocarCanal(int canal) => _comandosTelevisao.TrocarCanal(canal);

        public void ExibirInformacoes() => _comandosTelevisao.ExibirInformacoes();
    }
}
