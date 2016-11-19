using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class AtividadesController : ApiController
    {
        [Route("api/atividades")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Atividade> Get()
        {
            return PharmaCRM.Lib_Primavera.PriIntegration.GetListaAtividades();
        }

        [Route("api/atividades/{id}")]
        [HttpGet]
        public Lib_Primavera.Model.Atividade Get(string id)
        {
            Lib_Primavera.Model.Atividade atividade = PharmaCRM.Lib_Primavera.PriIntegration.GetAtividade(id);

            if (atividade == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return PharmaCRM.Lib_Primavera.PriIntegration.GetAtividade(id);
            }                       
        }

        [Route("api/atividades")]
        [HttpPost]
        public HttpResponseMessage Post(Lib_Primavera.Model.Atividade atividade)
        {
            Lib_Primavera.Model.RespostaErro respostaErro = new Lib_Primavera.Model.RespostaErro();
            respostaErro = Lib_Primavera.PriIntegration.InsereObjAtividade(atividade);
            if (respostaErro.Erro == 0)
            {
                return Request.CreateResponse(HttpStatusCode.Created, atividade);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, respostaErro.Descricao);
            }
        }

        [Route("api/atividades/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(Lib_Primavera.Model.Atividade atividade)
        {
            Lib_Primavera.Model.RespostaErro respostaErro = new Lib_Primavera.Model.RespostaErro();
            try
            {
                respostaErro = Lib_Primavera.PriIntegration.UpdAtividade(atividade);
                if (respostaErro.Erro == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, respostaErro.Descricao);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, respostaErro.Descricao);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, respostaErro.Descricao);
            }
        }
    }
}
