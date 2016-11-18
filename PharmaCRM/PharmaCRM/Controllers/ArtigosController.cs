using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class ArtigosController : ApiController
    {
        // GET api/artigos
        // Lista com detalhes completos dos Artigos
        [Route("api/artigos")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Artigo> Get()
        {
            return Lib_Primavera.PriIntegration.ListaArtigos();
        }

        // GET api/artigos/5
        // Detalhes completos do Artigo
        [Route("api/artigos/{id}")]
        [HttpGet]
        public Lib_Primavera.Model.Artigo Get(string id)
        {
            Lib_Primavera.Model.Artigo artigo = Lib_Primavera.PriIntegration.GetArtigo(id);

            if (artigo == null) {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artigo;
        }

        // POST api/artigos
        [Route("api/artigos")]
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // PUT api/artigos/5
        [Route("api/artigos/{id}")]
        [HttpPut]
        public void Put(string id, [FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // DELETE api/artigos/5
        [Route("api/artigos/{id}")]
        [HttpDelete]
        public void Delete(string id)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
