using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class Artigo
    {
        public string Codigo
        {
            get;
            set;
        }

        public string Descricao
        {
            get;
            set;
        }

        public double StockAtual
        {
            get;
            set;
        }

        public double PrecoUltimo
        {
            get;
            set;
        }

        public double PrecoMedio
        {
            get;
            set;
        }

        public string Iva
        {
            get;
            set;
        }

        public int PrazoEntrega
        {
            get;
            set;
        }

        public List<double> PVPs
        {
            get;
            set;
        }
    }
}