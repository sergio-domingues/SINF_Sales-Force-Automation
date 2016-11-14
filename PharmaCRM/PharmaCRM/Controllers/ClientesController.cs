using PharmaCRM.Lib_Primavera.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class ClientesController : ApiController
    {
        public IEnumerable<Cliente> GetCliente()
        {
            return PharmaCRM.Lib_Primavera.PriIntegration.ListaClientes();
        }
    }
}
