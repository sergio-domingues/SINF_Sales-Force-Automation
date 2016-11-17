using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class StockController : ApiController
    {
        // GET api/stock
        public IEnumerable<Lib_Primavera.Model.StockArtigo> Get()
        {
            return Lib_Primavera.PriIntegration.GetStock();
        }

        // GET api/stock/5
        public Lib_Primavera.Model.StockArtigo Get(string id)
        {
            return Lib_Primavera.PriIntegration.GetStockArtigo(id);
        }

        // POST api/stock
        public void Post([FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // PUT api/stock/5
        public void Put(string id, [FromBody]string value)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // DELETE api/stock/5
        public void Delete(string id)
        {
            // TODO
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}