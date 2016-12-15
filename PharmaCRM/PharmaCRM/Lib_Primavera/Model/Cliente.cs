using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class Cliente
    {
        public FaturacaoCliente DetalhesFaturacao
        {
            get;
            set;
        }

        public string Morada
        {
            get;
            set;
        }

        public string Localidade
        {
            get;
            set;
        }

        public string Notas
        {
            get;
            set;
        }

        public string CodCliente
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public string NumContribuinte
        {
            get;
            set;
        }

        public string Telefone
        {
            get;
            set;
        }
    }
}