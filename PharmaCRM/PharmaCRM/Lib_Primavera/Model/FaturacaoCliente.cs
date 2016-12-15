using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class FaturacaoCliente
    {
        public FaturacaoCliente()
        {
            ValorFaturado = 0;
            ValorPorFaturar = 0;
        }

        public double ValorFaturado
        {
            get;
            set;
        }

        public double ValorPorFaturar
        {
            get;
            set;
        }

    }
}