using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class StockArtigoArmazem
    {
        public string Armazem
        {
            get;
            set;
        }

        public string Lote
        {
            get;
            set;
        }

        public double StockAtual
        {
            get;
            set;
        }

        public string Localizacao
        {
            get;
            set;
        }

        public double QuantidadeReservada
        {
            get;
            set;
        }

        public double UltimaContagem
        {
            get;
            set;
        }

        public DateTime DataUltimaContagem
        {
            get;
            set;
        }

        public double PrecoMedio
        {
            get;
            set;
        }

        public double PrecoUltimo
        {
            get;
            set;
        }

        public bool BloqueadoInventario
        {
            get;
            set;
        }
    }
}