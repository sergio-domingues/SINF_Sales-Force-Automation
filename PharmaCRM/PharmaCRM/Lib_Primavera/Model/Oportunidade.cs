using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.CrmBE900;

namespace PharmaCRM.Lib_Primavera.Model
{
    // http://www.primaverabss.com/pkb/Homepage-Detalhes_Artigo2.aspx?SourceID=c2d14572-bdba-4a38-af6b-36b1ac4f8bc9&Level=4&ParentCat=C&CatPath=C17DD489-AF4C-11E3-A101-00155D0ECE6A%40TBL%40C&ItemKey=CabecOportunidadesVenda
    public class Oportunidade
    {
        public string id
        {
            get;
            set;
        }

        public string codigo
        {
            get;
            set;
        }

        public string descricao
        {
            get;
            set;
        }

        public int numEncomenda
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

        public DateTime dataCriacao
        {
            get;
            set;
        }

        public DateTime dataExpiracao
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