using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class KPI
    {
        public KPI()
        {
            ProdutosMaisVendidos = new Dictionary<string, double>();
            MelhoresClientes = new Dictionary<string, double>();
        }

        public string IdVendedor
        {
            get;
            set;
        }

        // Current month
        public double NumTotalVendas
        {
            get;
            set;
        }

        // Current month
        public double ValorTotalVendas
        {
            get;
            set;
        }

        // Maps product ID to ammount sold (current month)
        public Dictionary<string, double> ProdutosMaisVendidos
        {
            get;
            set;
        }

        // Current month
        public int NumVendasCompletas
        {
            get;
            set;
        }

        // Last 3 months
        public int NumOportunidadesPendentes
        {
            get;
            set;
        }

        // Current month
        public int NovasOportunidades
        {
            get;
            set;
        }

        // Last 3 months
        public int NumClientesAtivos
        {
            get;
            set;
        }

        // Last 3 months (valor de compra)
        public Dictionary<string, double> MelhoresClientes
        {
            get;
            set;
        }
    }
}