using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class ObjetivosController : ApiController
    {
        // GET: api/Objetivos
        public IEnumerable<string> Get()
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // GET: api/Objetivos/5
        public string Get(int id)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // POST: api/Objetivos
        public void Post([FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // PUT: api/Objetivos/5
        public void Put(int id, [FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // DELETE: api/Objetivos/5
        public void Delete(int id)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
