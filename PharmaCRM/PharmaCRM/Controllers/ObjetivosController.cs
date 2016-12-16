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
            IEnumerable<Lib_Primavera.Model.Objetivo> objs = Lib_Primavera.PharmaCRM.getObjetivosVendedores();

            if(objs == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError));
            }

            return objs;
        }
        
        [Route("api/objetivos/{idVendedor}")]
        [HttpGet]
        public Lib_Primavera.Model.Objetivo Get(string idVendedor)
        {

            Lib_Primavera.Model.Objetivo obj = Lib_Primavera.PharmaCRM.getObjetivoVendedor(idVendedor);

            if (obj == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return obj;
        }
        
        // PUT: api/Objetivos/5
        [Route("api/objetivos/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]double value)
        {
            Lib_Primavera.Model.Objetivo obj = new Lib_Primavera.Model.Objetivo();
            obj.Vendedor = id;
            obj.Valor = value;
            if (!Lib_Primavera.PharmaCRM.updateCreateObjetivo(obj))
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Objetivos/5
        public void Delete(string idVendedor)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
