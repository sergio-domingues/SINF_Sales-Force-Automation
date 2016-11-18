using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class EncomendasClienteController : ApiController
    {
        // GET: api/EncomendasCliente

        public IEnumerable<Lib_Primavera.Model.Encomenda> Get()
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // GET: api/EncomendasCliente/5
        public List<Lib_Primavera.Model.Encomenda> Get(string id)
        {
            return Lib_Primavera.PriIntegration.GetEncomendasCliente(id);
        }

        // POST: api/EncomendasCliente
        public void Post([FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // PUT: api/EncomendasCliente/5
        public void Put(int id, [FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // DELETE: api/EncomendasCliente/5
        public void Delete(int id)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
