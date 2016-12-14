using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCRM.Lib_Primavera.Model
{
    public class ObjetivoEstado : Objetivo
    {
        public ObjetivoEstado() : base() {}

        public double ValorCumprido
        {
            get;
            set;
        }
    }
}