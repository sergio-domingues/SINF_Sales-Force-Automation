using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class KPIController : ApiController
    {
        // GET: api/KPI
        [Route("api/kpi")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.KPI> Get()
        {
            IEnumerable<Lib_Primavera.Model.KPI> kpis = Lib_Primavera.PriIntegration.getKPIs();
            
            if (kpis == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return kpis;
        }

        // GET: api/KPI/5
        [Route("api/kpi/{idVendedor}")]
        [HttpGet]
        public Lib_Primavera.Model.KPI Get(string idVendedor)
        {
            Lib_Primavera.Model.KPI kpis = Lib_Primavera.PriIntegration.getVendedorKPIs(idVendedor);

            if (kpis == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return kpis;
        }

        [Route("api/kpi")]
        [HttpPost]
        public void Post([FromBody]string value)
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        [Route("api/kpi/{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        [Route("api/kpi/{numDoc}")]
        [HttpDelete]
        public void Delete(int id)
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
