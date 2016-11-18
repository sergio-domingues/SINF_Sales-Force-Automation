using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class Encomenda
    {
        public string Entidade
        {
            get;
            set;
        }

        public int NumeroDocumento
        {
            get;
            set;
        }

        public DateTime Data
        {
            get;
            set;
        }

        public double TotalMercadoria
        {
            get;
            set;
        }

        public string Serie
        {
            get;
            set;
        }

        public List<Model.LinhaEncomenda> LinhasDocumento

        {
            get;
            set;
        }

        public string idInterno
        {
            get;
            set;
        }
    }
}