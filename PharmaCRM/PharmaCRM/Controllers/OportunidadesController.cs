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
        [Route("api/oportunidades")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Oportunidade> Get()
        {
            return Lib_Primavera.PriIntegration.getOportunidades();
        }

        [Route("api/oportunidades/{id}")]
        [HttpGet]
        public Lib_Primavera.Model.Oportunidade Get(string id)
        {
            return Lib_Primavera.PriIntegration.getOportunidade(id);
        }

        [Route("api/oportunidades/{id}/atividades")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Atividade> GetAtividades(string id)
        {
            return Lib_Primavera.PriIntegration.getAtividadesDeOportunidade(id);
        }
        
        [Route("api/oportunidades")]
        [HttpPost]
        public HttpResponseMessage Post(Lib_Primavera.Model.Oportunidade Oportunidade)
        {
            Lib_Primavera.Model.RespostaErro respostaErro = new Lib_Primavera.Model.RespostaErro();
            respostaErro = Lib_Primavera.PriIntegration.createOportunidade(Oportunidade);

            if (respostaErro.Erro == 0)
            {
                return Request.CreateResponse(HttpStatusCode.Created, Oportunidade);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, respostaErro.Descricao);
            }
        }
    }
}
