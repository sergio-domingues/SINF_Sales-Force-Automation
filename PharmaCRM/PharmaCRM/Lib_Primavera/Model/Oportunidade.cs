using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class Oportunidade
    {
        public string id
        {
            get;
            set;
        }

        public string descricao
        {
            get;
            set;
        }

        public string entidade
        {
            get;
            set;
        }

        public string tipoEntidade
        {
            get;
            set;
        }

        public string vendedor
        {
            get;
            set;
        }

        public double valorTotalOV
        {
            get;
            set;
        }
    }
}