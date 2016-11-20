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
        [Route("api/encomendas/{id}")]
        [HttpGet]
        public Lib_Primavera.Model.Encomenda Get(int id)
        {
            return Lib_Primavera.PriIntegration.GetEncomenda(id, true);
        }

        // POST: api/Encomendas
        [Route("api/encomendas")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Lib_Primavera.Model.Encomenda encomenda)
        {
            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();
            erro = Lib_Primavera.PriIntegration.CreateEncomenda(encomenda);
            
            if (erro.Erro == 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, encomenda.idInterno);
                return Request.CreateResponse(HttpStatusCode.Created, encomenda);;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
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
        [Route("api/encomendas/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            return Lib_Primavera.PriIntegration.DeleteEncomenda(id).Descricao.ToString();
        }
    }
}
