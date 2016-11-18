using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class VendedoresController : ApiController
    {
        [Route("api/vendedores")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Vendedor> Get()
        {
            return PharmaCRM.Lib_Primavera.PriIntegration.ListaVendedores();
        }

        [Route("api/vendedores/{id}")]
        [HttpGet]
        public Lib_Primavera.Model.Vendedor Get(String id)
        {
            Lib_Primavera.Model.Vendedor vendedor = PharmaCRM.Lib_Primavera.PriIntegration.GetVendedor(id);
            if (vendedor == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return vendedor;
            }
        }


        // http://localhost:49559/api/vendedores/1/atividades?dataInicio=2010-11-15&dataFim=2016-11-15

        [Route("api/vendedores/{id}/atividades")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Atividade> GetVendedorAtividades(string id, [FromUri] string dataInicio, [FromUri] string dataFim)
        {
            return Lib_Primavera.PriIntegration.GetVendedorAtividades(id, dataInicio, dataFim);
        }

        [Route("api/vendedores/{id}/encomendas")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Encomenda> GetVendedorEncomendas(string id)
        {
            return Lib_Primavera.PriIntegration.GetEncomendasVendedor(id);
        }
    }
}
