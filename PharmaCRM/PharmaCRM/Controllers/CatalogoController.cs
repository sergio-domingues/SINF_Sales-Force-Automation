using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class CatalogoController : ApiController
    {
        // GET api/catalogo
        // Lista de resumos de artigos
        [Route("api/catalogo")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.ArtigoResumo> Get()
        {
            return Lib_Primavera.PriIntegration.ListaArtigosResumo();
        }

        // GET api/catalogo/5
        // Resumos de artigo
        [Route("api/catalogo/{id}")]
        [HttpGet]
        public Lib_Primavera.Model.ArtigoResumo Get(string id)
        {
            Lib_Primavera.Model.ArtigoResumo artigo = Lib_Primavera.PriIntegration.GetArtigoResumo(id);

            if (artigo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artigo;
        }
    }
}
