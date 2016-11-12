using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PharmaCRM.Lib_Primavera.Model;

namespace PharmaCRM.Controllers
{
    public class CustomerController : ApiController
    {
        //
        // GET api/customers

        public IEnumerable<Lib_Primavera.Model.Customer> Get()
        {
            return Lib_Primavera.PriIntegration.ListaClientes();
        }

        // GET api/customers/<id>
        public Customer Get(string id)
        {
            Lib_Primavera.Model.Customer customer = Lib_Primavera.PriIntegration.GetCliente(id);
            if (customer == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return customer;
            }
        }

    }
}
