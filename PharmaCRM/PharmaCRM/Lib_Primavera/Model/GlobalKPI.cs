using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class GlobalKPI : KPI
    {
        public GlobalKPI() : base() {}

        // Last 3 months
        public double ValorMedioVendasPorVendedor
        {
            get;
            set;
        }

        // Last 3 months (valor de venda)
        public Dictionary<string, double> MelhoresVendedores
        {
            get;
            set;
        }
    }
}