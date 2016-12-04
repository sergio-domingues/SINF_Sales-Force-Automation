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
        /**
        * GET api/artigos
        * Lista com detalhes completos dos Artigos
        *
        * @return Uma lista de artigos.
        */
        [Route("api/artigos")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Artigo> Get()
        {
            return Lib_Primavera.PriIntegration.ListaArtigos();
        }

        /**
        * GET api/artigos/<id>
        * Detalhes completos do Artigo
        *
        * @param id ID do artigo
        * @return O Artigo corresponde ou código 404 em caso de erro.
        */
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
    }
}
