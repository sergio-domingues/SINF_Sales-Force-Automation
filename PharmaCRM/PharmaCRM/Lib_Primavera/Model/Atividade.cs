using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class Atividade
    {
        //todo ENUM for attr type

        public String id
        {
            get;
            set;
        }

        public String idTipoAtividade
        {
            get;
            set;
        }

        public int estado
        {
            get;
            set;
        }

        public DateTime dataInicio
        {
            get;
            set;
        }

        public DateTime dataFim
        {
            get;
            set;
        }

        public string descricao
        {
            get;
            set;
        }

        public string idContactoPrincipal
        {
            get;
            set;
        }

        public string idCabecalhoOportunidadeVenda
        {
            get;
            set;
        }

        public string vendedor
        {
            get;
            set;
        }

        public string local
        {
            get;
            set;
        }

    }
}
