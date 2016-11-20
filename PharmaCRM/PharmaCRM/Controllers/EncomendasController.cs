using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class EncomendasController : ApiController
    {
        // GET: api/Encomendas
        [Route("api/encomendas")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Encomenda> Get()
        {
            return Lib_Primavera.PriIntegration.GetEncomendas(false);
        }

        // GET: api/Encomendas/5
        [Route("api/encomendas/{numDoc}")]
        [HttpGet]
        public Lib_Primavera.Model.Encomenda Get(int numDoc)
        {
            return Lib_Primavera.PriIntegration.GetEncomenda(numDoc, true);
        }

        // POST: api/Encomendas
        [Route("api/encomendas")]
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        [Route("api/encomendas/{id}")]
        [HttpPut]
        // PUT: api/Encomendas/5
        public void Put(int id, [FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // DELETE: api/Encomendas/5
        [Route("api/encomendas/{numDoc}")]
        [HttpDelete]
        public void Delete(int numDoc)
        {
            Lib_Primavera.PriIntegration.DeleteEncomenda(numDoc);
        }
    }
}
