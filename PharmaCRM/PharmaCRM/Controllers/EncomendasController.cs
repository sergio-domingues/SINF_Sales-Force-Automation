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

        // GET: api/Encomendas/15D3E72F-7A0A-11E6-A55F-080027184ECD
        [Route("api/encomendas/{id}")]
        [HttpGet]
        public Lib_Primavera.Model.Encomenda Get(string id)
        {
            Lib_Primavera.Model.Encomenda enc = Lib_Primavera.PriIntegration.GetEncomenda(id, true);

            if (enc == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return enc;
        }

        /*
        {
            "Entidade": "MICROAVI",
            "Data": "2016-10-07T00:00:00",
            "idResponsavel": "2",
            "LinhasDocumento": [
                {
                    "CodigoArtigo": "A0001",
                    "Quantidade": 1,
                    "Desconto": 0,
                    "PrecoUnitario": 1000
                }
            ]
        }
        */
        // POST: api/Encomendas
        [Route("api/encomendas")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Lib_Primavera.Model.Encomenda encomenda)
        {
            return editaCriaEncomenda(encomenda);
        }

        // PUT: api/Encomendas/5
        [Route("api/encomendas/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Lib_Primavera.Model.Encomenda encomenda)
        {
            return editaCriaEncomenda(encomenda);
        }

        private HttpResponseMessage editaCriaEncomenda(Lib_Primavera.Model.Encomenda encomenda)
        {
            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();
            erro = Lib_Primavera.PriIntegration.CreateEncomenda(encomenda);

            if (erro.Erro == 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, encomenda.idInterno);
                return Request.CreateResponse(HttpStatusCode.Created, encomenda);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro.Descricao);
            }
        }

        // DELETE: api/Encomendas/5
        [Route("api/encomendas/{numDoc}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            Lib_Primavera.Model.RespostaErro erro = Lib_Primavera.PriIntegration.AnulaEncomenda(id);

            if (erro.Erro != 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
