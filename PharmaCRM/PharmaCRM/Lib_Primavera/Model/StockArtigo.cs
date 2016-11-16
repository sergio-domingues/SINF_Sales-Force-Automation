using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class StockArtigo
    {
        public string CodigoArtigo
        {
            get;
            set;
        }

        public List<Model.StockArtigoArmazem> Stocks
        {
            get;
            set;
        }
    }
}