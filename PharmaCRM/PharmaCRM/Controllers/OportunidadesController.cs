using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{

    public class OportunidadesController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.Oportunidade> Get()
        {
            return Lib_Primavera.PriIntegration.getOportunidades();
        }

        public Lib_Primavera.Model.Oportunidade Get(string id)
        {
            return Lib_Primavera.PriIntegration.getOportunidade(id);
        }/*

        [Route("api/oportunidades/{id}/atividades")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Atividade> GetAtividades(string id)
        {
            return Lib_Primavera.PriIntegration.GetAtividadesDeOportunidade(id);
        }

        [HttpPost]
        public HttpResponseMessage Post(Lib_Primavera.Model.Oportunidade Oportunidade)
        {
            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();
            erro = Lib_Primavera.PriIntegration.InsereOportunidadeObj(Oportunidade);

            if (erro.Erro == 0)
            {
                var response = Request.CreateResponse(
                   HttpStatusCode.Created, Oportunidade);
                /*string uri = Url.Link("DefaultApi", new { CodCliente = cliente.CodCliente });
                response.Headers.Location = new Uri(uri);*/
           /*     return response;
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro.Descricao);
            }

        }*/
    }
}
