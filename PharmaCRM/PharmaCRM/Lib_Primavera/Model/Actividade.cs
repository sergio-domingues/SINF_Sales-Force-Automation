using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Models
{
    public class Actividade
    {
        //todo ENUM for attr type

        public DateTime data_inicio
        {
            get;
            set;
        }

        public string descricao
        {
            get;
            set;
        }

        public string tipo
        {
            get;
            set;
        }

        public bool terminada
        {
            get;
            set;
        }

        public string comercial 
        {
            get;
            set;
        }

        public string morada
        {
            get;
            set;
        }

    }
}
