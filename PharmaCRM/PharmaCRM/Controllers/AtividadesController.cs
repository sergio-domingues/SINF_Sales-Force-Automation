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
    }
}
