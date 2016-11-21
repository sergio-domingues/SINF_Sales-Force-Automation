using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class KPI
    {
        public string IdVendedor
        {
            get;
            set;
        }

        // Current month
        public double TotalSales
        {
            get;
            set;
        }

        // Current month
        public double TotalSaleValue
        {
            get;
            set;
        }

        // Maps product ID to ammount sold
        public Dictionary<string, double> TopSellingProducts
        {
            get;
            set;
        }

        // Current month
        public int NumCompletedSales
        {
            get;
            set;
        }

        // Last 3 months
        public int NumPendingOffers
        {
            get;
            set;
        }

        // Current month
        public int NewLeads
        {
            get;
            set;
        }

        // Last 3 months
        public int NumActiveCustomers
        {
            get;
            set;
        }

        // Last 3 months
        public List<string> TopCustomers
        {
            get;
            set;
        }
    }
}