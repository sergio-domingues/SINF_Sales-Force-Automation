using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class VendedoresController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.Vendedor> Get()
        {
            return PharmaCRM.Lib_Primavera.PriIntegration.ListaVendedores();
        }
    }
}
