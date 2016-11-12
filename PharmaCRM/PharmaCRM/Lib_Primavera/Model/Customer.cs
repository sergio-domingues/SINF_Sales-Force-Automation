using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class Customer
    {
        public string Morada;

        /* Exemplo para POST e GET com valores específicos
         public string Morada
        {
            get
            {
                return "MORADA: " + _morada;
            }
            set
            {
                _morada = value;
            }
        }
    
*/       
        public string CodCustomer
        {
            get;
            set;
        }

        public string NomeCustomer
        {
            get;
            set;
        }

        public string NumCustomer
        {
            get;
            set;
        }

        public string Moeda
        {
            get;
            set;
        }

    }
}