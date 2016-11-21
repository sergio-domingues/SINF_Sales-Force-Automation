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
        [Route("api/objetivos")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Objetivo> Get()
        {
            IEnumerable<Lib_Primavera.Model.Objetivo> objs = Lib_Primavera.PriIntegration.GetObjetivos();

            if(objs == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError));
            }

            return objs;
        }

        [Route("api/objetivos/{idVendedor}")]
        [HttpGet]
        public string Get(string idVendedor)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // POST: api/Objetivos
        public void Post([FromBody]Lib_Primavera.Model.Objetivo objetivo)
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
        public void Delete(string idVendedor)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
